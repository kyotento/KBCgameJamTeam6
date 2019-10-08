using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_Move : MonoBehaviour
{
   public Vector3 move = new Vector3();
    int m_timer = 0;
    Random m_rand;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController charaCon =
            gameObject.GetComponent<CharacterController>();
        m_timer++;
        if (m_timer < 300)
        {
            move.Set(0.03f, 0.0f, 0.0f);
        }
        if (m_timer >= 300&&m_timer<600)
        {
            move.Set(0.0f, 0.0f, 0.01f);
        }
        if (m_timer >= 600 && m_timer < 900)
        {
            move.Set(-0.03f, 0.0f, 0.0f);
        }
        if (m_timer >= 900 && m_timer < 1200)
        {
            move.Set(0.0f, 0.0f, -0.01f);
        }
        if(m_timer>=1200)
        {
            m_timer = 0;
        }
        charaCon.Move(move);
    }
}
