using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Animator animator;
    Animator feetAnim;
    Rigidbody2D rigidBody;
    public float movementStep = 0.1f;
    public float rotationStep = 1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        feetAnim = transform.GetChild(0).gameObject.GetComponent<Animator>();
        rigidBody= GetComponent<Rigidbody2D>();
    }

    void MoveForward(){
        rigidBody.position += new Vector2(transform.right.x, transform.right.y) * movementStep * Time.deltaTime;
        animator.SetFloat("isWalking", 2f);
        feetAnim.SetFloat("isWalking", 2f);
    }
    void MoveBackward(){
        rigidBody.position -= new Vector2(transform.right.x, transform.right.y) * movementStep * Time.deltaTime;
        animator.SetFloat("isWalking", 2f);
        feetAnim.SetFloat("isWalking", 2f);
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
        else if(Input.GetKeyUp(KeyCode.UpArrow)){
            animator.SetFloat("isWalking", 0f);
            feetAnim.SetFloat("isWalking", 0f);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            MoveBackward();
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow)){
            animator.SetFloat("isWalking", 0f);
            feetAnim.SetFloat("isWalking", 0f);
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
        else if(Input.GetKeyUp(KeyCode.W)){
            animator.SetFloat("isWalking", 0f);
            animator.SetFloat("isWalking", 0f);
        }
        if(Input.GetKey(KeyCode.S)){
            MoveBackward();
        }
        else if(Input.GetKeyUp(KeyCode.S)){
            animator.SetFloat("isWalking", 0f);
            animator.SetFloat("isWalking", 0f);
        }
        if(Input.GetKey(KeyCode.A)){
            RotateLeft();
        }
        if(Input.GetKey(KeyCode.D)){
            RotateRight();
        }
    }
}
