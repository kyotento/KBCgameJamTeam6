using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    public Vector3[] target = new Vector3[6];
    public Vector3 diff;
    Vector3 add;
    float y;
    public int i = 0;
    public int m_timer = 0;
    public int targetnum = 0;

    // Start is called before the first frame update
    void Start()
    {
        target[0].Set(-7.0f, 4.14f, 5.5f);
        target[1].Set(-7.0f, 4.14f, 7.5f);
        target[2].Set(5.25f, 4.14f, 8.7f);
        target[3].Set(-5.25f, 4.14f, 8.7f);
        target[4].Set(-8.25f, 4.14f, 5.5f);
        target[5].Set(-8.25f, 4.14f, 8.7f);


    }

    // Update is called once per frame
    void Update()
    {
        m_timer++;
        CharacterController charaCon =
            gameObject.GetComponent<CharacterController>();
        
            
        
        if (m_timer > 360)
        {

            targetnum = Random.Range(1, 6);
            
            m_timer = 0;
        }
        //y = m_timer*2.0f;
       // add.Set(0.0f, y, 0.0f);
        
        if (m_timer < 300)
        {

            diff.Set(0.0f, 0.0f, 0.0f);
        }
        if(m_timer>=0&&m_timer<55)
        {
            add.Set(0.0f, 0.5f, 0.0f);
        }
        if (m_timer >= 55.0f && m_timer < 110)
        {
            add.Set(0.0f, -0.5f, 0.0f);
        }
        diff = target[targetnum] - this.gameObject.transform.position+add;
        diff.Normalize();
        charaCon.Move(diff/4.0f);

    }
}
