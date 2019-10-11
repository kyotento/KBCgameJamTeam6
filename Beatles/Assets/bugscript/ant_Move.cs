using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ant_Move : MonoBehaviour
{
   public Vector3 move = new Vector3();
    Vector3 diff =new Vector3();
    int m_timer = 0;
    public int etimer =0;
   public bool escapeFlag = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Escape(Vector3 pos,bool flag)
    {
        escapeFlag = flag;
        diff = this.transform.position - pos;
        diff.Normalize();
        move += diff/50.0f;
        move.y = 0.0f;

    }
    // Update is called once per frame
    void Update()
    {
       //RockNotifyReceiver m_rock = this.GetComponent<RockNotifyReceiver>();
       ////m_rock.ReceiveRockAction();
        CharacterController charaCon =
          gameObject.GetComponent<CharacterController>();
        m_timer++;
        if(escapeFlag == true)
        {
            etimer++;
        }
        if(etimer++ > 300)
        {
            escapeFlag = false;
            etimer = 0;
        }
        if (escapeFlag == false)
        {
            if (m_timer < 300)
            {
                move.Set(0.03f, -0.1f, 0.0f);
            }
            if (m_timer >= 300 && m_timer < 600)
            {
                move.Set(0.0f, -0.1f, 0.01f);
            }
            if (m_timer >= 600 && m_timer < 900)
            {
                move.Set(-0.03f, -0.1f, 0.0f);
            }
            if (m_timer >= 900 && m_timer < 1200)
            {
                move.Set(0.0f, -0.1f, -0.01f);
            }
            if (m_timer >= 1200)
            {
                m_timer = 0;  
            }
        }

        charaCon.Move(move/5.0f);
    }
    
}
