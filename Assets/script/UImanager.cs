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
        // バッテリーを視覚化
        LightGauge.fillAmount = Player.GetComponent<PlayerController>().LightBattery / 100;

        // バッテリーが20%を切ったらゲージを赤に、それ以外なら緑に
        if (Player.GetComponent<PlayerController>().LightBattery < 20)
        {
            LightGauge.color = new Color(160,0, 0);
        }
        else
        {
            LightGauge.color = new Color(0, 160, 0);

        }

        // 心拍数を視覚化
       Heart.text ="" +  (int)Player.GetComponent<PlayerController>().HeartBeat;


        // 疲れているときはBPMの文字色を黄色に、それ以外なら赤に
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
