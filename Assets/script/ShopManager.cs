using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    int selectItemNum;

    Text CoinsText;
    Text ItemName, ItemHaveNum,ItemPrice, Itemexplanation;
    GameObject Cursor;

    GameObject[] ItemBox = new GameObject[Define.ItemNum];
    GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        // 現在選択中のアイテム番号を初期化
        selectItemNum = 0;
        // オブジェクトを取得
        CoinsText = GameObject.Find("Coins").GetComponent<Text>();
        ItemName = GameObject.Find("ItemName").GetComponent<Text>();
        ItemHaveNum = GameObject.Find("ItemHaveNums").GetComponent<Text>();
        ItemPrice = GameObject.Find("ItemPrice").GetComponent<Text>();
        Itemexplanation = GameObject.Find("Itemexplanation").GetComponent<Text>();
        Cursor = GameObject.Find("Cursor");
        // コインの枚数を更新
        CoinsText.text = "" + PlayerStateManager.haveCoins;
        // アイテム表示欄の取得、変更
        for (int i = 0; i < ItemManager.parameter.itemData.Count; i++)
        {
            // アイテム欄取得
            ItemBox[i] = GameObject.Find("ItemBox_" + i);
            // アイテムがある場合はアイテム画像の保存先から画像を取得し変更
            ItemBox[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(ItemManager.parameter.itemData[i].filename);
            // アイテムがある場合は画像の透明度を0にする
            ItemBox[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
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

        if (selectItemNum < 0) selectItemNum = ItemManager.parameter.itemData.Count - 1;
        if (selectItemNum > ItemManager.parameter.itemData.Count - 1) selectItemNum = 0;

        // カーソルの表示
        Cursor.transform.localPosition = ItemBox[selectItemNum].transform.localPosition;

        // 表示を更新
        ItemName.text = ItemManager.parameter.itemData[selectItemNum].name;
        ItemHaveNum.text = "所持数 : " + ItemManager.ItemHaveNum[selectItemNum];
        ItemPrice.text = "金額 : " + ItemManager.parameter.itemData[selectItemNum].price;
        Itemexplanation.text = ItemManager.parameter.itemData[selectItemNum].explanation;

        // 購入
        if (Input.GetKeyDown(KeyCode.Space) && ItemManager.parameter.itemData[selectItemNum].type)
        {
            if(ItemManager.parameter.itemData[selectItemNum].price < PlayerStateManager.haveCoins)
            {
                PlayerStateManager.haveCoins -= ItemManager.parameter.itemData[selectItemNum].price;
                ItemManager.ItemHaveNum[selectItemNum]++;

                // コインの枚数を更新
                CoinsText.text = "" + PlayerStateManager.haveCoins;

                ItemManager.FileSave();
                PlayerStateManager.FileSave();
            }

        }

        // タイトルへ戻る
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            SceneManager.LoadScene("Title");
        }
    }
}
