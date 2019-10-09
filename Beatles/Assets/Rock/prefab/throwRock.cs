using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwRock : MonoBehaviour
{

    bool isNotified = false;    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 1){
            //GetComponentInParent<Collider>().isTrigger = false;
        }
    }

    void OnCollisionEnter( Collision other){
        if(other.gameObject.tag == "stage"){         
        if(!isNotified){
            isNotified = true;
            Debug.Log("collide stage");    
            foreach(var bug in GameObject.FindGameObjectsWithTag("Bug")){
                bug.GetComponent<RockNotifyReceiver>().ReceiveRockAction(this.gameObject);
            }
        }
        }
    }



    public void Throw(Vector3 vel){        
        var rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.AddForce(vel * rb.mass, ForceMode.Impulse);
        Invoke("TriggerOff",0.3f);
    }

    void TriggerOff(){
        GetComponentInParent<Collider>().isTrigger = false;
    }
}
