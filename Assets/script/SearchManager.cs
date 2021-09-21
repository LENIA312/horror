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
        // ���ݑI�𒆂̃A�C�e���ԍ���������
        selectItemNum = 0;
        // �I�u�W�F�N�g���擾
        CoinsText = GameObject.Find("Coins").GetComponent<Text>();
        StageName = GameObject.Find("StageName").GetComponent<Text>();
        StageGoNum = GameObject.Find("StageGoNums").GetComponent<Text>();
        StageExplanation = GameObject.Find("StageExplanation").GetComponent<Text>();
        Cursor = GameObject.Find("Cursor");
        // �R�C���̖������X�V
        CoinsText.text = "" + PlayerStateManager.haveCoins;
        // �A�C�e���\�����̎擾�A�ύX
        for (int i = 0; i < StageManager.parameter.StageData.Count; i++)
        {
            // �A�C�e�����擾
            StageBox[i] = GameObject.Find("StageBox_" + i);
            // �A�C�e��������ꍇ�̓A�C�e���摜�̕ۑ��悩��摜���擾���ύX
            StageBox[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(StageManager.parameter.StageData[selectItemNum].filename);
            // �A�C�e��������ꍇ�͉摜�̓����x��0�ɂ���
            StageBox[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
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

        if (selectItemNum < 0) selectItemNum = StageManager.parameter.StageData.Count - 1;
        if (selectItemNum > StageManager.parameter.StageData.Count - 1) selectItemNum = 0;

        // �J�[�\���̕\��
        Cursor.transform.localPosition = StageBox[selectItemNum].transform.localPosition;

        // �\�����X�V
        StageName.text = StageManager.parameter.StageData[selectItemNum].name;
        StageExplanation.text = StageManager.parameter.StageData[selectItemNum].explanation;
        StageGoNum.text = "�o���� : " + StageManager.StageGoNum[selectItemNum];

        if (Input.GetKeyDown(KeyCode.Space) && StageManager.parameter.StageData[selectItemNum].type)
        {
            SceneManager.LoadScene(StageManager.parameter.StageData[selectItemNum].scenename);
        }

        // �^�C�g���֖߂�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}

