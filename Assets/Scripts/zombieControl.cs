using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class zombieControl : MonoBehaviour
{
    Animator animator;
    bool isRotating;
    bool isAttacking;
    public float movementSpeed;
    public float rotationSpeed;
    System.Random rnd;// To randomise left or right turns
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        isRotating = false;
        animator = GetComponent<Animator>();
        rotationSpeed = 90;
        rnd = new System.Random();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Wall")){
            isRotating = true;
            if(rnd.Next(0,100)<75){
                rotationSpeed *= -1;
            }
            animator.SetFloat("isWalking", 0f);
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.CompareTag("Wall")){
            transform.Rotate(0, 0, rotationSpeed);
        }

    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Wall")){
            isRotating = false;
        }
    }

    void MoveForward(){
        rigidBody.position += new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;        
        animator.SetFloat("isWalking", 1f);
    }

    void Update()
    {
        if(isRotating == false){
            MoveForward();
        }
    }
    

}
