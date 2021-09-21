using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    #region [ ステージデータクラス ]
    [System.Serializable]
    public class StageData
    {
        public bool type;
        public string name;
        public string explanation;
        public string filename;
        public string scenename;
    }

    public class JsonData
    {
        public List<StageData> StageData;
    }
    #endregion

    // アイテムデータを宣言
    public static JsonData parameter = new JsonData();

    public static int[] StageGoNum = new int[Define.StageNum];


    public enum ITEM
    {
        BATTERY,
        FILM
    }

    // ファイルの読み込み
    public static void FileRoad()
    {
        for (int i = 0; i < StageGoNum.Length; i++)
        {
            // アイテムのデータを取得
            StageGoNum[i] = PlayerPrefs.GetInt("STAGEGO_" + i, 0);
        }

        // jsonを読み込み
        string json = Resources.Load<TextAsset>("STAGEDATA").ToString();

        // 読み込んだjsonをクラスにシリアライズ
        parameter = JsonUtility.FromJson<JsonData>(json);
    }

    // ファイルの書き込み
    public static void FileSave()
    {
        for (int i = 0; i < StageGoNum.Length; i++)
        {
            // アイテムのデータを保存
            PlayerPrefs.SetInt("STAGEGO_" + i, StageGoNum[i]);
            PlayerPrefs.Save();
        }

    }
}
