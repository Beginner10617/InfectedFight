using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementStep = 0.025f;
    public float rotationStep = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveForward(){
        GetComponent<Rigidbody2D>().position += new Vector2(transform.right.x, transform.right.y) * movementStep;
    }
    void MoveBackward(){
        GetComponent<Rigidbody2D>().position -= new Vector2(transform.right.x, transform.right.y) * movementStep;
    }
    void RotateRight(){
        transform.Rotate(0, 0, -rotationStep);
    }
    void RotateLeft(){
        transform.Rotate(0, 0, rotationStep);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            MoveForward();
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            MoveBackward();
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            RotateRight();
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            RotateLeft();
        }
        if(Input.GetKey(KeyCode.W)){
            MoveForward();
        }
        if(Input.GetKey(KeyCode.S)){
            MoveBackward();
        }
        if(Input.GetKey(KeyCode.A)){
            RotateLeft();
        }
        if(Input.GetKey(KeyCode.D)){
            RotateRight();
        }
    }
}
