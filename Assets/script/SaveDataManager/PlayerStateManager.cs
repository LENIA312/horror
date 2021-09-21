using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStateManager
{ 
    // コインの所持数
    public static int haveCoins;

    // ファイルの読み込み
    public static void FileRoad()
    {
        // コインのデータを取得
        haveCoins = PlayerPrefs.GetInt("COIN", 0);

    }

    // ファイルの書き込み
    public static void FileSave()
    {
        PlayerPrefs.SetInt("COIN", haveCoins);
        PlayerPrefs.Save();


    }
}
