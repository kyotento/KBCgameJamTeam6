using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNotifyReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveRockAction(GameObject rock){
        Debug.Log("received rock acction");
        //        
        //GetComponent<Rigidbody>().AddForce(0,10,0,ForceMode.Impulse);
    }
}
