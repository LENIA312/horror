using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    #region [ �X�e�[�W�f�[�^�N���X ]
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

    // �A�C�e���f�[�^��錾
    public static JsonData parameter = new JsonData();

    public static int[] StageGoNum = new int[Define.StageNum];


    public enum ITEM
    {
        BATTERY,
        FILM
    }

    // �t�@�C���̓ǂݍ���
    public static void FileRoad()
    {
        for (int i = 0; i < StageGoNum.Length; i++)
        {
            // �A�C�e���̃f�[�^���擾
            StageGoNum[i] = PlayerPrefs.GetInt("STAGEGO_" + i, 0);
        }

        // json��ǂݍ���
        string json = Resources.Load<TextAsset>("STAGEDATA").ToString();

        // �ǂݍ���json���N���X�ɃV���A���C�Y
        parameter = JsonUtility.FromJson<JsonData>(json);
    }

    // �t�@�C���̏�������
    public static void FileSave()
    {
        for (int i = 0; i < StageGoNum.Length; i++)
        {
            // �A�C�e���̃f�[�^��ۑ�
            PlayerPrefs.SetInt("STAGEGO_" + i, StageGoNum[i]);
            PlayerPrefs.Save();
        }

    }
}
