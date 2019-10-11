using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translucent : MonoBehaviour
{

    private int countPlusBug = 0;
    public bool isGameOver = false;
    public AudioSource sippaiSE;
    public bool isGameClear = false;
    // Start is called before the first frame update    
    void Start()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0.95f;

        gameObject.GetComponent<Renderer>().material.color = color;

    }

    // Update is called once per frame
    void Update()
    {        
        if(countPlusBug == 3){
            isGameClear = true;
        }
    }

    void OnTriggerEnter(Collider col) 
    {        

        if(isGameClear || isGameOver) return;
        if(col.gameObject.name == "tentou")
        {
            countPlusBug++;
            Debug.Log("てんとう虫");

            col.gameObject.GetComponent<tentou_Move>().stopflag = true;
        }
        if(col.gameObject.name == "ant")
        {
            isGameOver = true;
            sippaiSE.Play();
            col.gameObject.GetComponent<ant_Move>().stopflag = true;
            Debug.Log("あり");
        }
        if(col.gameObject.name == "rolypolymodoli")
        {
            countPlusBug++;
            col.gameObject.GetComponent<ant_Move>().stopflag = true;
            Debug.Log("ダンゴムシ");
        }
        if(col.gameObject.name == "bug1")
        {
            countPlusBug++;
            col.gameObject.GetComponent<batta_Move>().stopflag = true;
            Debug.Log("雲");
        }
        if(col.gameObject.name == "Sphere")
        {
            isGameOver = true;
            sippaiSE.Play();
            col.gameObject.GetComponent<spider_Move>().stopflag = true;
            Debug.Log("バッタ");
        }
    }
}
