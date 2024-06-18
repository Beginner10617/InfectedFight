using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    GameObject UpperBody;
    GameObject LowerBody;
    Animator animator;
    Animator feetAnim;
    Rigidbody2D rigidBody;
    public bool enableArrow = true;
    public float movementSpeed = 0.75f;
    public float fastwalkSpeed = 1.5f;
    public float slowwalkSpeed;
    public float strafeSpeed = 0.6f;
    public float rotationSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        UpperBody = GameObject.FindWithTag("UpperBody");
        if (UpperBody == null) {
            Debug.Log("UpperBody not found by camera");
        }
        animator = UpperBody.GetComponent<Animator>();
        LowerBody = GameObject.FindWithTag("LowerBody");
        if (LowerBody == null) {
            Debug.Log("LowerBody not found by camera");
        }
        feetAnim = LowerBody.GetComponent<Animator>();
        rigidBody= GetComponent<Rigidbody2D>();
        slowwalkSpeed = movementSpeed;
    }

    void MoveForward(){
        rigidBody.position += new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;        
        animator.SetFloat("isWalking", 1f);
        if(movementSpeed == slowwalkSpeed){
            feetAnim.SetFloat("isWalking", 1f);
        }
        else if(movementSpeed == fastwalkSpeed){
            feetAnim.SetFloat("isWalking", 4f);

        }
    }
    void MoveBackward(){
        rigidBody.position -= new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;
        animator.SetFloat("isWalking", 1f);
        if(movementSpeed == slowwalkSpeed){
            feetAnim.SetFloat("isWalking", 1f);
        }
        else if(movementSpeed == fastwalkSpeed){
            feetAnim.SetFloat("isWalking", 4f);

        }
    }
    void RotateRight(){
        transform.Rotate(0, 0, -rotationSpeed);
    }
    void RotateLeft(){
        transform.Rotate(0, 0, rotationSpeed);
    }
    void StrafeRight(){
        rigidBody.position -= new Vector2(transform.up.x, transform.up.y) * strafeSpeed * Time.deltaTime;
        animator.SetFloat("isWalking", 0f);
        feetAnim.SetFloat("isWalking", 2f);
    }
    void StrafeLeft(){
        rigidBody.position += new Vector2(transform.up.x, transform.up.y) * strafeSpeed * Time.deltaTime;
        animator.SetFloat("isWalking", 0f);
        feetAnim.SetFloat("isWalking", 3f);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = fastwalkSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)){
            movementSpeed = slowwalkSpeed;
        }
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            movementSpeed = fastwalkSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.RightShift)){
            movementSpeed = slowwalkSpeed;
        }
        if(enableArrow){
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
                StrafeRight();
            }
            else if(Input.GetKeyUp(KeyCode.RightArrow)){
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 0f);
            }
            if(Input.GetKey(KeyCode.LeftArrow)){
                StrafeLeft();
            }
            else if(Input.GetKeyUp(KeyCode.LeftArrow)){
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 0f);
            }
        }
        else{
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
            if(Input.GetKey(KeyCode.D)){
                StrafeRight();
            }
            else if(Input.GetKeyUp(KeyCode.D)){
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 0f);
            }
            if(Input.GetKey(KeyCode.A)){
                StrafeLeft();
            }
            else if(Input.GetKeyUp(KeyCode.A)){
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 0f);
            }
        }
        if(Input.GetKey(KeyCode.Q)){
            RotateLeft();
        }
        if(Input.GetKey(KeyCode.E)){
            RotateRight();
        }
    }
}
