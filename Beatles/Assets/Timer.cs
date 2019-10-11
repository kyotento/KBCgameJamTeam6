using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;

    public bool Clear = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 1 && Clear == false)
        {
            time -= Time.deltaTime;
            int t = Mathf.FloorToInt(time);
            Text uiText = GetComponent<Text>();
            uiText.text = "のこり" + t + "びょう";
        }
    }
}
