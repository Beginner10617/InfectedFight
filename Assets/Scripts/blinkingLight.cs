using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; 
using System;
public class blinkingLight : MonoBehaviour
{
    Light2D lights;
    float angle;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        lights = GetComponent<Light2D>();
        angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lights.intensity = (float) Math.Abs(Math.Sin(angle));   
        angle += speed;
        if(angle > 2*3.14159f)
        {angle -= 2*3.14159f;}
    }

}