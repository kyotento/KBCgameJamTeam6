﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batta_Move : MonoBehaviour
{

    public Vector3[] target = new Vector3[6];
    public Vector3 diff;
    public Vector3 rockdiff;
    Vector3 add;
    float y;
    public int i = 0;
    public int m_timer = 0;
    public int etimer = 0;
    public int targetnum = 0;
    public bool escapeFlag = false;
    public Vector3 move;

    public bool stopflag = false;
    bool sss = false;
    int stimer = 0;
    GameObject goal;
    public Vector3 g_diff;
    // Start is called before the first frame update
    void Start()
    {
        target[0].Set(-7.0f, 4.14f, 5.5f);
        target[1].Set(-7.0f, 4.14f, 7.5f);
        target[2].Set(0.0f, 4.14f, 7.7f);
        target[3].Set(-5.25f, 4.14f, 7.7f);
        target[4].Set(-3.0f, 4.14f, 4.7f);
        target[5].Set(-8.25f, 4.14f, 7.7f);

        goal = GameObject.Find("Sphere (1)");
    }

    public void Escape(Vector3 pos, bool flag)
    {
        escapeFlag = flag;
        rockdiff.Set(0.0f, 0.0f, 0.0f);
        rockdiff = this.transform.position - pos;
        rockdiff.Normalize();
        move += rockdiff/30.0f;
        move.y = -1.0f;

    }
    // Update is called once per frame
    void Update()
    {
        CharacterController charaCon =
               gameObject.GetComponent<CharacterController>();
        if (stopflag)
            {
                stimer++;
                g_diff = goal.transform.position - this.transform.position;
            charaCon.Move(g_diff / 30.0f);

            }
            if (stimer > 40)
            {
                sss = true;
            }
        if (sss == false)
        {
            m_timer++;
           

            if (escapeFlag)
            {
                etimer++;
            }
            if (etimer++ > 500)
            {
                escapeFlag = false;

                etimer = 0;
            }

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
            if (m_timer >= 0 && m_timer < 55)
            {
                add.Set(0.0f, 0.5f, 0.0f);
            }
            if (m_timer >= 55.0f && m_timer < 110)
            {
                add.Set(0.0f, -0.5f, 0.0f);
            }
            if (stopflag == false)
            {
                if (escapeFlag == false)
                {

                    diff = target[targetnum] - this.gameObject.transform.position + add;
                    diff.Normalize();
                    charaCon.Move(diff / 30.0f);

                }
                else charaCon.Move(move / 3.0f);

            }


        }
    }
}
