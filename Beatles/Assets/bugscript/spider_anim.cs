using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider_anim : MonoBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play();
    }
}
