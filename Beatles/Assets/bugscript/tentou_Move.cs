using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentou_Move : MonoBehaviour
{
    public Vector3 move = new Vector3();
    Vector3 diff = new Vector3();
    int m_timer = 0;
    public int etimer = 0;
    public bool escapeFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Escape(Vector3 pos, bool flag)
    {
        escapeFlag = flag;
        diff = this.transform.position - pos;
        diff.Normalize();
        move += diff /50.0f;
        move.y = 0.0f;

    }
    // Update is called once per frame
    void Update()
    {
        CharacterController charaCon =
          gameObject.GetComponent<CharacterController>();
        charaCon.Move(move);
    }
}
