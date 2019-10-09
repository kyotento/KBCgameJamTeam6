﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
    }
    public float rotSpeed = 5;

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
        float rx = Input.GetAxis("Horizontal2") * rotSpeed;
        float rz = Input.GetAxis("Vertical2") * rotSpeed;

        move.x = lx * speed;
        move.z = lz * speed;


        //Vector3 angle = new Vector3(- rz * rotSpeed, rx * rotSpeed, 0);
        //if(angle.y >= 0.99f)
        //{
        //    angle.y = 0.99f;
        //}
        //if(angle.y <= - 0.99f)
        //{
        //    angle.y = -0.99f;
        //}

        float maxLimit = 60, minLimit = 360 - maxLimit;

        //y回転。
        var localAngle = transform.localEulerAngles;
        localAngle.x -= rz;
        if (localAngle.x > maxLimit && localAngle.x < 180)
            localAngle.x = maxLimit;
        if (localAngle.x < minLimit && localAngle.x > 180)
            localAngle.x = minLimit;
        mainCamera.transform.localEulerAngles = localAngle;
        //x回転。
        var angle = transform.eulerAngles;
        angle.y += rx;
        mainCamera.transform.eulerAngles = angle;

        charaCon.Move(move);

    }
}
