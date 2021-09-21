using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    static bool boot = false;
    [SerializeField] GameObject selectArrow;
    [SerializeField] Text Coins;

    enum MENU
    {
        SEARCH,
        SHOP,
        INVENTORY,
        RECORD,
        EOF
    }
    MENU selectMenu;

    Vector3[] ArrowPoint = new[]
    {
        new Vector3(-80,70,0),
        new Vector3(-80,0,0),
        new Vector3(-100,-70,0),
        new Vector3(-120,-140,0),
    };

    private void Awake()
    {
        // ソフトの初回起動時のみロード
        if (!boot) {
            // アイテムデータのロード
            ItemManager.FileRoad();
            // プレイヤーのデータロード
            PlayerStateManager.FileRoad();
            //ステージデータのロード
            StageManager.FileRoad();
            boot = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        selectMenu = MENU.SEARCH;
        Coins.text = "" + PlayerStateManager.haveCoins;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerStateManager.haveCoins = 99999;
            PlayerStateManager.FileSave();
        }

            if (Input.GetKeyDown(KeyCode.W)) selectMenu--;
        if (Input.GetKeyDown(KeyCode.S)) selectMenu++;

        if (selectMenu < 0) selectMenu = MENU.EOF - 1;
        if (selectMenu > MENU.EOF - 1) selectMenu = 0;

        if(selectMenu > MENU.EOF) Debug.Log("ERRORCODE : 101");

        selectArrow.transform.localPosition = ArrowPoint[(int)selectMenu];

        // スペースキーでシーンチェンジ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (selectMenu)
            {
                case MENU.SEARCH:
                    SceneManager.LoadScene("Search");
                    break;

                case MENU.SHOP:
                    SceneManager.LoadScene("Shop");
                    break;

                case MENU.INVENTORY:
                    SceneManager.LoadScene("Inventory");
                    break;

                case MENU.RECORD:
                    SceneManager.LoadScene("Record");
                    break;

                default:
                    Debug.Log("ERRORCODE : 102");
                    break;
            }
        }

    }
}
