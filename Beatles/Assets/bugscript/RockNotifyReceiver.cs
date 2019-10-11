using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNotifyReceiver : MonoBehaviour
{
    public Vector3 diff;
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

        foreach(var bug in GameObject.FindGameObjectsWithTag("Bug"))
        {
            diff = bug.transform.position - rock.transform.position;
            if (diff.sqrMagnitude<10.0f)
            {
                if(bug.GetComponent<ant_Move>())
                {
                    bug.GetComponent<ant_Move>().Escape(rock.transform.position,true); 
                }
                //if(bug.GetComponent<spider_Move>().)
                if (bug.GetComponent<tentou_Move>())
                {
                    bug.GetComponent<tentou_Move>().Escape(rock.transform.position, true);
                }
            }
            
        }
        //        
        //GetComponent<Rigidbody>().AddForce(0,10,0,ForceMode.Impulse);
    }
}
