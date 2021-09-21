using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Image LightGauge;
    [SerializeField] Text Heart;

    float tt;
    bool bpmFlg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �o�b�e���[�����o��
        LightGauge.fillAmount = Player.GetComponent<PlayerController>().LightBattery / 100;

        // �o�b�e���[��20%��؂�����Q�[�W��ԂɁA����ȊO�Ȃ�΂�
        if (Player.GetComponent<PlayerController>().LightBattery < 20)
        {
            LightGauge.color = new Color(160,0, 0);
        }
        else
        {
            LightGauge.color = new Color(0, 160, 0);

        }

        // �S���������o��
       Heart.text ="" +  (int)Player.GetComponent<PlayerController>().HeartBeat;


        // ���Ă���Ƃ���BPM�̕����F�����F�ɁA����ȊO�Ȃ�Ԃ�
        if (Player.GetComponent<PlayerController>().tired)
        {
            Heart.color = Color.yellow;
        }
        else
        {
            Heart.color = Color.red;
        }

    }
}
