using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translucent : MonoBehaviour
{

    private int countPlusBug = 0;
    public bool isGameOver = false;
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

    void OnCollisionEnter (Collision col)
    {
        if(isGameClear || isGameOver) return;
        if(col.gameObject.name == "tentou")
        {
            countPlusBug++;
        }
        if(col.gameObject.name == "ant")
        {
            isGameOver = true;
        }
        if(col.gameObject.name == "rolypolymodoli")
        {
            countPlusBug++;   
        }
        if(col.gameObject.name == "bug1")
        {
            countPlusBug++;
        }
        if(col.gameObject.name == "Sphere")
        {
            isGameOver = true;
        }
    }
}
