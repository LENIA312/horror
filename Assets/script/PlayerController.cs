using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // プレイヤーステータス
    public float HeartBeat;
    public bool tired;
    float tiredTimer;

    // 移動変数
    float x, z; // 座標
    [SerializeField] float initSpeed; // 初期速度
    float speed; // 移動速度

    // カメラ関連変数
    public GameObject cam; // カメラオブジェクト
    Quaternion cameraRot, charaRot; // カメラとキャラクター
    float xScensityvity = 3f, yScensityvity = 3f; // カメラ方向移動速度
    float fieldViw;

    public GameObject Light; // 懐中電灯
    bool LightFlg; // 懐中電灯オンオフフラグ
    public float LightBattery; // 懐中電灯バッテリー

    // Start is called before the first frame update
    void Start()
    {
        // 各Quaternionを設定
        cameraRot = cam.transform.localRotation;
        charaRot = transform.localRotation;

        // 懐中電灯をオフ
        LightFlg = true;
        // 懐中電灯のバッテリーを初期化
        LightBattery = 100;

        // 心拍数の初期化
        HeartBeat = 0;

        // 疲労フラグの初期化
        tired = false;

    }

    // Update is called once per frame
    void Update()
    {
        // キーの入力に応じて移動
        x = z = 0;
        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        //transform.position += new Vector3(x,0,z);
        transform.position += cam.transform.forward * z + cam.transform.right * x;

        //Debug.Log("心拍数 : " + HeartBeat);

        // マウスの移動座標に応じて方向変換
        float xRot = Input.GetAxis("Mouse X") * yScensityvity;
        float yRot = Input.GetAxis("Mouse Y") * xScensityvity;

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        charaRot *= Quaternion.Euler(0, xRot, 0);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = charaRot;
        Light.transform.localRotation = cameraRot;



        // 懐中電灯切り替え
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 懐中電灯の切り替え
            LightFlg = LightFlg ? false : true;
        }

        // バッテリー消耗
        if (LightFlg)
        {
            LightBattery-=0.001f;
            // 0以下にならないように
            if (LightBattery < 0) LightBattery = 0;
        }

        // バッテリーが0だったら消す
        if (LightBattery <= 0) LightFlg = false;

        Light.SetActive(LightFlg);


        /********************/


        /********************/
    }

    private void FixedUpdate()
    {



        // ダッシュ
        // シフトを押しつつ疲れていなかったら
        if (Input.GetKey(KeyCode.LeftShift) && !tired)
        {
            // 移動速度を速く
            speed = initSpeed * 1.5f;
            // 視野角を調整
            if (fieldViw < 10) fieldViw += ( Time.deltaTime * 70);

            // 心拍数の上昇
            HeartBeat += 0.1f;
        }
        else
        {
            // 移動速度を初期化
            speed = initSpeed;
            // 視野角を調整
            if (fieldViw > 0) fieldViw -= ( Time.deltaTime * 70);

            //心拍数の低下
            HeartBeat -= 0.12f;
        }

        // 視野角を調整
        cam.GetComponent<Camera>().fieldOfView = 60 + fieldViw;

        // 心拍数が10に達したら疲れる
        if (HeartBeat > 120)tired = true;
        // 疲れてから5秒経ったら疲労回復
        if (tired)
        {
            tiredTimer += Time.deltaTime;
            if (tiredTimer > 5)
            {
                tired = false;
                tiredTimer = 0;
            }
        }

        //心拍数が0以下にならないように
        if (HeartBeat < 0) HeartBeat = 0;


    }

    // バッテリーを増やす
    public void BatteryPlus(float _plus)
    {
        // バッテリーを増やす
        LightBattery += _plus;
        // 最大値以上だったら最大値に固定する
        if (LightBattery > 100) LightBattery = 100;
    }
}
