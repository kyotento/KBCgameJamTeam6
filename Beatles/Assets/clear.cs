using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
    static bool ReStart = false;

    //Findしなくてもいい
    [SerializeField] GameObject ooo;
    [SerializeField] GameObject clea;
    [SerializeField] GameObject sippai;
    [SerializeField] AudioSource clearSe;       //成功音。
    [SerializeField] AudioSource sippaiSe;      //失敗音。
    [SerializeField] AudioSource clearflag;     //成功。
    [SerializeField] AudioSource sippaiflag;     //失敗。
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

        var sif = sippaiflag.GetComponent<Translucent>().isGameOver;
        var sef = sippaiflag.GetComponent<Translucent>().isGameClear;

        //失敗条件。
        //もし残り時間が０になった時または失敗フラグがたったとき。
        if (timer < 1 || sif == true)
        {
       
            sippai.GetComponent<RawImage>().enabled = true;
            sippaiSe.Play();            //失敗音流す。
            ReStart = true;

            cf = true;
          
        }

        //成功条件。
        //虫が全員入った。
        if( sef == true )
        {
            clea.GetComponent<RawImage>().enabled = true;
            clearSe.Play();         //成功流す。
            cf = true;
            ReStart = true;
        }

        //クリアか失敗した時。
        if(ReStart == true)
        {
            if(Input.GetKeyDown("joystick button 1"))
            {
                ReStart = false;
                SceneManager.LoadScene("Title");    //タイトル流す。
                sippaiSe.Stop();                    //失敗音流す。
                clearSe.Stop();                    //成功音流す。
            }
        }

    }
}
