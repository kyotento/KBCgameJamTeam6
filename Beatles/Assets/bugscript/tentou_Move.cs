using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentou_Move : MonoBehaviour
{
    public bool deathflag = false;
    public bool stopflag = false;
    int stimer = 0;
    public Vector3 move = new Vector3();
    public Vector3 move2 = new Vector3();
    Vector3 diff = new Vector3();
    private float gravity = 9.80665f;
    int m_timer = 0;
    public int etimer = 0;
    public Vector3 pl_diff;
    
    public bool escapeFlag = false;
    public GameObject player;
    GameObject goal;
    public Vector3 g_diff;
    // Start is called before the first frame update
    void Start()
    {
        //if (player == null)
        
        player = GameObject.Find("Main Camera");
        goal = GameObject.Find("Sphere (1)");
        
    }
    public void Escape(Vector3 pos, bool flag)
    {
        escapeFlag = flag;
        diff = this.transform.position - pos;
        diff.Normalize();
        move += diff /50.0f;
        move.y = 0.0f;

    }
    public void Stop()
    {
        if(stopflag)
        {
            stimer++;
            g_diff = goal.transform.position - this.transform.position;
        }
        if(stimer<40)
        {

        }
    }
    // Update is called once per frame
    void Update()
    {

        CharacterController charaCon =
          gameObject.GetComponent<CharacterController>();

        if (escapeFlag == true)
        {
            etimer++;

        }
        if (etimer > 120.0f)
        {
            escapeFlag = false;
            etimer = 0;

        }
        if (!charaCon.isGrounded)
        {
            move.y -= gravity * Time.deltaTime;
        }
        if (escapeFlag == false)
        {

            pl_diff = player.transform.position - this.transform.position;
            pl_diff.y = 0.0f;
            pl_diff.Normalize();
            move2 = pl_diff / 100.0f;
            charaCon.Move(move2);
        }
        else charaCon.Move(move);
    }
}
