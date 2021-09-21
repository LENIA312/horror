using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemManager
{
    #region [ アイテムデータクラス ]
    [System.Serializable]
    public class ItemData
    {
        public bool type;
        public string name;
        public int price;
        public string explanation;
        public string filename;
    }

    public class JsonData
    {
        public List<ItemData> itemData;
    }
    #endregion

    // アイテムデータを宣言
    public static JsonData parameter = new JsonData();
    // データ書き込み用変数
    static StreamWriter writer;

    public static int[] ItemHaveNum = new int[Define.ItemNum];


    public enum ITEM
    {
        BATTERY,
        FILM
    }

    // ファイルの読み込み
    public static void FileRoad()
    {
        for(int i = 0;i< ItemHaveNum.Length; i++)
        {
            // アイテムのデータを取得
            ItemHaveNum[i] = PlayerPrefs.GetInt("ITEM_" + i, 0);
        }

        // jsonを読み込み
        string json = Resources.Load<TextAsset>("ITEMDATA").ToString();

        // 読み込んだjsonをクラスにシリアライズ
        parameter = JsonUtility.FromJson<JsonData>(json);
    }

    // ファイルの書き込み
    public static void FileSave()
    {
        for (int i = 0; i < ItemHaveNum.Length; i++)
        {
            // アイテムのデータを保存
            PlayerPrefs.SetInt("ITEM_" + i, ItemHaveNum[i]);
            PlayerPrefs.Save();
        }

    }

}
