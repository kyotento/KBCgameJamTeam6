using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_Move : MonoBehaviour
{

    public  Vector3[] target = new Vector3[6];
    public Vector3 diff;
    public int i =0;
    public int m_timer = 0;
    public int targetnum = 0;

    // Start is called before the first frame update
    void Start()
    {
        target[0].Set(0.0f, 4.14f, 5.5f);
        target[1].Set(0.0f, 4.14f, 5.5f);
        target[2].Set(5.25f, 4.14f, 8.7f);
        target[3].Set(-5.25f, 4.14f, 8.7f);
        target[4].Set(-8.25f, 4.14f, 5.5f);
        target[5].Set(-8.25f, 4.14f, 8.7f);
    }

    // Update is called once per frame
    void Update()
    {
        m_timer++;
        
        var charaCon =
            gameObject.GetComponent<CharacterController>();

        if (m_timer > 90)
        {
            targetnum = Random.Range(1, 6);
            
            m_timer = 0;
        }
        
        diff = target[targetnum] - this.gameObject.transform.position;
       
        diff.Normalize();

        charaCon.Move(diff/80.0f);
        

    }
}
