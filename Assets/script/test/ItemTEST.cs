using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTEST : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        ItemManager.FileRoad();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ItemManager.parameter.itemData[(int)ItemManager.ITEM.FILM].price += 5;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ItemManager.FileSave();
        }
    }
}
