using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_management : MonoBehaviour
{
    public bool deathflag = false;
    public bool isStop = false;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Sphere (1)");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
