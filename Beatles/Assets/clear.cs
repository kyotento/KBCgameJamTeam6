using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{

    [SerializeField] GameObject ooo;
    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {

        //タイマー検索。
        var timer = ooo.GetComponent<Timer>().time;
        //失敗条件。
        //もし残り時間が０になった時。
        if (timer <= 0)
        {

        }

    }
}
