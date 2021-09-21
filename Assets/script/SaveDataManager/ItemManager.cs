using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemManager
{
    #region [ �A�C�e���f�[�^�N���X ]
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

    // �A�C�e���f�[�^��錾
    public static JsonData parameter = new JsonData();
    // �f�[�^�������ݗp�ϐ�
    static StreamWriter writer;

    public static int[] ItemHaveNum = new int[Define.ItemNum];


    public enum ITEM
    {
        BATTERY,
        FILM
    }

    // �t�@�C���̓ǂݍ���
    public static void FileRoad()
    {
        for(int i = 0;i< ItemHaveNum.Length; i++)
        {
            // �A�C�e���̃f�[�^���擾
            ItemHaveNum[i] = PlayerPrefs.GetInt("ITEM_" + i, 0);
        }

        // json��ǂݍ���
        string json = Resources.Load<TextAsset>("ITEMDATA").ToString();

        // �ǂݍ���json���N���X�ɃV���A���C�Y
        parameter = JsonUtility.FromJson<JsonData>(json);
    }

    // �t�@�C���̏�������
    public static void FileSave()
    {
        for (int i = 0; i < ItemHaveNum.Length; i++)
        {
            // �A�C�e���̃f�[�^��ۑ�
            PlayerPrefs.SetInt("ITEM_" + i, ItemHaveNum[i]);
            PlayerPrefs.Save();
        }

    }

}
