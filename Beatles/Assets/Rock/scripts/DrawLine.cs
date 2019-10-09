using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject preLineRenderer;
    public GameObject preBullet;
    private GameObject objLineRenderer;
    private GameObject objBullet;
    private LineRenderer lineRenderer;
    private int count = 0;
    public float mass = 1f, drag = 1f, x = 0f, y = -3f, z = 0f, initVel = 10f, angle = 0f, step = 0.05f, time = 0;
    private float gravity = 9.80665f;
    public Vector3 vel;

    public Vector3 velo;
 
	// Use this for initialization
	void Start () {
        angle = 30f * Mathf.Deg2Rad;
        vel = new Vector3(initVel * Mathf.Cos(angle), initVel * Mathf.Sin(angle), 0);

        //test
        vel = velo;

        objLineRenderer = Instantiate(preLineRenderer, gameObject.transform);
        objLineRenderer.transform.localPosition = Vector3.zero;
        lineRenderer = objLineRenderer.GetComponent<LineRenderer>();
 
        Time.timeScale = 0.2f;        

        objBullet = Instantiate(preBullet,gameObject.transform);            
        objBullet.GetComponent<Rigidbody>().useGravity = false;
    }
 
    void DisZeroDrag()
    {
        //if (y >= 0)
        {
            x = vel.x * time;
            z = vel.z * time;
            y = vel.y * time - 0.5f * gravity * (time * time + time * Time.fixedDeltaTime);
            lineRenderer.positionCount = count + 1;
            lineRenderer.SetPosition(count, new Vector3(x + this.transform.position.x, y + this.transform.position.y, z + transform.position.z));
            count++;
            time += step;

            
        }
    }
 
 
    // Update is called once per frame
    void Update () {

        DisZeroDrag();
        
        if(Input.GetKeyDown(KeyCode.Space)){
            objBullet.GetComponent<Rigidbody>().useGravity = true;
            objBullet.GetComponent<Rigidbody>().AddForce(vel * mass,ForceMode.Impulse);
            Debug.Log(vel * mass);
        }
    }
}
