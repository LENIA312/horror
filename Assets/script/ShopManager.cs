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
        // ���ݑI�𒆂̃A�C�e���ԍ���������
        selectItemNum = 0;
        // �I�u�W�F�N�g���擾
        CoinsText = GameObject.Find("Coins").GetComponent<Text>();
        ItemName = GameObject.Find("ItemName").GetComponent<Text>();
        ItemHaveNum = GameObject.Find("ItemHaveNums").GetComponent<Text>();
        ItemPrice = GameObject.Find("ItemPrice").GetComponent<Text>();
        Itemexplanation = GameObject.Find("Itemexplanation").GetComponent<Text>();
        Cursor = GameObject.Find("Cursor");
        // �R�C���̖������X�V
        CoinsText.text = "" + PlayerStateManager.haveCoins;
        // �A�C�e���\�����̎擾�A�ύX
        for (int i = 0; i < ItemManager.parameter.itemData.Count; i++)
        {
            // �A�C�e�����擾
            ItemBox[i] = GameObject.Find("ItemBox_" + i);
            // �A�C�e��������ꍇ�̓A�C�e���摜�̕ۑ��悩��摜���擾���ύX
            ItemBox[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(ItemManager.parameter.itemData[i].filename);
            // �A�C�e��������ꍇ�͉摜�̓����x��0�ɂ���
            ItemBox[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // �I���𑀍�
        if (Input.GetKeyDown(KeyCode.A)) selectItemNum--;
        if (Input.GetKeyDown(KeyCode.D)) selectItemNum++;

        if (Input.GetKeyDown(KeyCode.W)) selectItemNum -= 5;
        if (Input.GetKeyDown(KeyCode.S)) selectItemNum += 5;

        if (selectItemNum < 0) selectItemNum = ItemManager.parameter.itemData.Count - 1;
        if (selectItemNum > ItemManager.parameter.itemData.Count - 1) selectItemNum = 0;

        // �J�[�\���̕\��
        Cursor.transform.localPosition = ItemBox[selectItemNum].transform.localPosition;

        // �\�����X�V
        ItemName.text = ItemManager.parameter.itemData[selectItemNum].name;
        ItemHaveNum.text = "������ : " + ItemManager.ItemHaveNum[selectItemNum];
        ItemPrice.text = "���z : " + ItemManager.parameter.itemData[selectItemNum].price;
        Itemexplanation.text = ItemManager.parameter.itemData[selectItemNum].explanation;

        // �w��
        if (Input.GetKeyDown(KeyCode.Space) && ItemManager.parameter.itemData[selectItemNum].type)
        {
            if(ItemManager.parameter.itemData[selectItemNum].price < PlayerStateManager.haveCoins)
            {
                PlayerStateManager.haveCoins -= ItemManager.parameter.itemData[selectItemNum].price;
                ItemManager.ItemHaveNum[selectItemNum]++;

                // �R�C���̖������X�V
                CoinsText.text = "" + PlayerStateManager.haveCoins;

                ItemManager.FileSave();
                PlayerStateManager.FileSave();
            }

        }

        // �^�C�g���֖߂�
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            SceneManager.LoadScene("Title");
        }
    }
}
