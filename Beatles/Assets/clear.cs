using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clear : MonoBehaviour
{
    static bool ReStart = false;

    //Findしなくてもいい
    [SerializeField] GameObject ooo;
    [SerializeField] GameObject clea;
    [SerializeField] GameObject sippai;
    // Start is called before the first frame update
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {

        //タイマー検索。
        var timer = ooo.GetComponent<Timer>().time;
        //クリア判定検索。
        var cf = ooo.GetComponent<Timer>().Clear;

        //失敗条件。
        //もし残り時間が０になった時。
        if (timer < 1)
        {
            if(true)
            {
                sippai.GetComponent<RawImage>().enabled = true;
                ReStart = true;

                cf = true;
            }
        }

        //成功条件。
        //虫が全員入った。
        if( false )
        {
            clea.GetComponent<RawImage>().enabled = true;
            cf = true;
            ReStart = true;
        }

        //クリアか失敗した時。
        if(ReStart == true)
        {

        }

    }
}
