using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SearchManager : MonoBehaviour
{
    int selectItemNum;

    Text CoinsText;
    Text StageName, StageGoNum, StageExplanation;
    GameObject Cursor;

    GameObject[] StageBox = new GameObject[Define.StageNum];

    // Start is called before the first frame update
    void Start()
    {
        // 現在選択中のアイテム番号を初期化
        selectItemNum = 0;
        // オブジェクトを取得
        CoinsText = GameObject.Find("Coins").GetComponent<Text>();
        StageName = GameObject.Find("StageName").GetComponent<Text>();
        StageGoNum = GameObject.Find("StageGoNums").GetComponent<Text>();
        StageExplanation = GameObject.Find("StageExplanation").GetComponent<Text>();
        Cursor = GameObject.Find("Cursor");
        // コインの枚数を更新
        CoinsText.text = "" + PlayerStateManager.haveCoins;
        // アイテム表示欄の取得、変更
        for (int i = 0; i < StageManager.parameter.StageData.Count; i++)
        {
            // アイテム欄取得
            StageBox[i] = GameObject.Find("StageBox_" + i);
            // アイテムがある場合はアイテム画像の保存先から画像を取得し変更
            StageBox[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(StageManager.parameter.StageData[selectItemNum].filename);
            // アイテムがある場合は画像の透明度を0にする
            StageBox[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // 選択を操作
        if (Input.GetKeyDown(KeyCode.A)) selectItemNum--;
        if (Input.GetKeyDown(KeyCode.D)) selectItemNum++;

        if (Input.GetKeyDown(KeyCode.W)) selectItemNum -= 5;
        if (Input.GetKeyDown(KeyCode.S)) selectItemNum += 5;

        if (selectItemNum < 0) selectItemNum = StageManager.parameter.StageData.Count - 1;
        if (selectItemNum > StageManager.parameter.StageData.Count - 1) selectItemNum = 0;

        // カーソルの表示
        Cursor.transform.localPosition = StageBox[selectItemNum].transform.localPosition;

        // 表示を更新
        StageName.text = StageManager.parameter.StageData[selectItemNum].name;
        StageExplanation.text = StageManager.parameter.StageData[selectItemNum].explanation;
        StageGoNum.text = "出発数 : " + StageManager.StageGoNum[selectItemNum];

        if (Input.GetKeyDown(KeyCode.Space) && StageManager.parameter.StageData[selectItemNum].type)
        {
            SceneManager.LoadScene(StageManager.parameter.StageData[selectItemNum].scenename);
        }

        // タイトルへ戻る
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}

