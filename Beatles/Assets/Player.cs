using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        CharacterController charaCon = gameObject.GetComponent<CharacterController>();

        Vector3 move = new Vector3();
        charaCon.Move(move);

        //if(Input.GetKey(KeyCode.A))
        //{
        //    move.x -= 0.1f * speed;
        //}

        //if(Input.GetKey(KeyCode.D))
        //{
        //    move.x += 0.1f * speed;
        //}

        //if(Input.GetKey(KeyCode.W))
        //{
        //    move.z += 0.1f * speed;
        //}

        //if(Input.GetKey(KeyCode.S))
        //{
        //    move.z -= 0.1f * speed;
        //}

        // 左スティックのよこ方向の傾き
        Input.GetAxis("Horizontal");

        // 左スティックのたて方向の傾き
        Input.GetAxis("Vertical");

        // 右スティックのよこ方向の傾き
        Input.GetAxis("Horizontal2");

        // 右スティックのたて方向の傾き
        Input.GetAxis("Vertical2");

        float lx = Input.GetAxis("Horizontal");
        float lz = Input.GetAxis("Vertical");
        float rx = Input.GetAxis("Horizontal2");
        float rz = Input.GetAxis("Vertical2");

    
       

        charaCon.Move(move);

    }
}
