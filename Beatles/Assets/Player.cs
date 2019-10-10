using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject mainCamera;

    [SerializeField] GameObject rockPrefab;
    [SerializeField] Vector3 handPos;

    [SerializeField] GameObject arrow;
    private GameObject standbyRock;
    bool hasRock = true;

    private float gravity = 9.80665f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
        var ps = this.transform.position;
        standbyRock = Instantiate(rockPrefab,gameObject.transform);  
        standbyRock.GetComponent<Collider>().isTrigger = true;                 
        standbyRock.transform.parent = null;
    }
    public float rotSpeed = 5;

    public float speed = 5;
    
    private Vector3 fallPos;
    float x,y,z;
    // Update is called once per frame
    void Update()
    {
        CharacterController charaCon = gameObject.GetComponent<CharacterController>();

        Vector3 move = new Vector3();
        charaCon.Move(move);


        var thvec = this.transform.forward * 2;
        thvec.y += 3f;     

        if(hasRock){
            var handPos = transform.position;
            handPos += (transform.forward * 0.5f);      
            handPos.y -= 0.5f;      
            standbyRock.transform.SetPositionAndRotation(handPos,transform.rotation);
            
            var time = 0f;            
            for(int i = 0; i < 5000; i++){
                 x = thvec.x * time;
                 z = thvec.z * time;
                 y = thvec.y * time - 0.5f * gravity * (time * time + time * Time.fixedDeltaTime);
                time += 0.5f;
                if(y < 0) break;
            }
            fallPos = new Vector3(x + this.transform.position.x, y + this.transform.position.y, z + transform.position.z);
            fallPos.y = 0f;
            arrow.transform.SetPositionAndRotation(fallPos,Quaternion.identity);
            Debug.Log(fallPos);
            

        }

        //石を投げる処理。
        if(Input.GetKeyDown("joystick button 4") || Input.GetKeyDown("joystick button 5") || Input.GetKeyDown(KeyCode.Space)){
            if (hasRock){   
                standbyRock.GetComponent<throwRock>().Throw(thvec);                
                hasRock = false;  
                Invoke("Reload",1);
            }
        }
        

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

    void Reload(){
        hasRock = true;
        standbyRock = Instantiate(rockPrefab,gameObject.transform);                   
        standbyRock.transform.parent = null;
        standbyRock.GetComponent<Collider>().isTrigger = true;        
    }
}
