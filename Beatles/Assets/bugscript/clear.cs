using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    [SerializeField] GameObject timerTextObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Timerの検索。
       var a =  timerTextObj.GetComponent<Timer>().time;
        //タイマーが０になったら失敗と出す。
        if (a <= 0)
        {

        }
    }
}
