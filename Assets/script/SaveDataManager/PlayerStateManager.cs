using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStateManager
{ 
    // �R�C���̏�����
    public static int haveCoins;

    // �t�@�C���̓ǂݍ���
    public static void FileRoad()
    {
        // �R�C���̃f�[�^���擾
        haveCoins = PlayerPrefs.GetInt("COIN", 0);

    }

    // �t�@�C���̏�������
    public static void FileSave()
    {
        PlayerPrefs.SetInt("COIN", haveCoins);
        PlayerPrefs.Save();


    }
}
