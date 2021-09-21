using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogController : MonoBehaviour
{
    [SerializeField] GameObject Log;
    [SerializeField] Text LogText;
    float tt;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

         tt += Time.deltaTime;
         if(tt > 1)
         {
               tt = 0;
               Log.SetActive(false);
         }

    }

    public void LogShow(string _text){
        LogText.text = _text;
        Log.SetActive(true);
    }
}
