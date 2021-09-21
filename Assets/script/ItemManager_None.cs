using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager_None : MonoBehaviour
{
    [SerializeField] GameObject Log;
    GameObject Pointer; // �|�C���^�[���Q��

    // Start is called before the first frame update
    void Start()
    {
        Pointer = GameObject.Find("Pointer");
    }

    // Update is called once per frame
    void Update()
    {
        // �|�C���^�[����Ray���΂��A�Փː�̃^�O�������̃^�O�ƈ�v��������s
        Ray ray = Camera.main.ScreenPointToRay(Pointer.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (hit.collider.tag == this.tag && Input.GetKeyDown(KeyCode.E))
            {
                // �o�b�e���[�𑝂₷
                GameObject.Find("Player").GetComponent<PlayerController>().BatteryPlus(50);
                // ����������
                hit.collider.gameObject.SetActive(false);
                Log.GetComponent<LogController>().LogShow("�d�r���E����");
            }
        }
    }

}
