using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager_None : MonoBehaviour
{
    [SerializeField] GameObject Log;
    GameObject Pointer; // ポインターを参照

    // Start is called before the first frame update
    void Start()
    {
        Pointer = GameObject.Find("Pointer");
    }

    // Update is called once per frame
    void Update()
    {
        // ポインターからRayを飛ばし、衝突先のタグが自分のタグと一致したら実行
        Ray ray = Camera.main.ScreenPointToRay(Pointer.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (hit.collider.tag == this.tag && Input.GetKeyDown(KeyCode.E))
            {
                // バッテリーを増やす
                GameObject.Find("Player").GetComponent<PlayerController>().BatteryPlus(50);
                // 自分を消す
                hit.collider.gameObject.SetActive(false);
                Log.GetComponent<LogController>().LogShow("電池を拾った");
            }
        }
    }

}
