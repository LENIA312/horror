using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RecordManager : MonoBehaviour
{
    Text Coins;

    // Start is called before the first frame update
    void Start()
    {
        Coins = GameObject.Find("Coins").GetComponent<Text>();
        // コインを更新
        Coins.text = "" + PlayerStateManager.haveCoins;
    }

    // Update is called once per frame
    void Update()
    {
        // タイトルへ戻る
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }


}
