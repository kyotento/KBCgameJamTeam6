using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Throw(Vector3 vel){
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(vel * rb.mass, ForceMode.Impulse);
    }
}
