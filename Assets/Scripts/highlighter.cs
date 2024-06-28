using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class highlighter : MonoBehaviour
{
    public float speed;
    public float amplification;
    Vector3 meanPosition = new Vector3(0,0,0);
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = 0f;
        meanPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        transform.position = transform.up * amplification * (float) Math.Sin(angle) + meanPosition;
        if(angle > 2 * 3.14159f){
            angle -= 2*3.14159f;
        }
    }
}
