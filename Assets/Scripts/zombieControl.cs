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
    float rotationSpeed;
    GameObject player;
    GameObject healthBar;
    System.Random rnd;// To randomise left or right turns
    Rigidbody2D rigidBody;
    public float hitpoint;
    public float damage;// damage per second
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        if (player == null) {
            Debug.Log("Player not found by zombie control");
        }
        healthBar = transform.GetChild(0).gameObject;
        healthBar.SetActive(false);
        rigidBody = GetComponent<Rigidbody2D>();
        isRotating = false;
        animator = GetComponent<Animator>();
        rotationSpeed = 90;
        rnd = new System.Random();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Wall")||col.gameObject.CompareTag("Zombie")){
            isRotating = true;
            if(rnd.Next(0,100)<75){
                rotationSpeed *= -1;
            }
            animator.SetFloat("isWalking", 0f);
        }
        if(col.gameObject.CompareTag("Player")){
            isAttacking = true;
            animator.SetFloat("isWalking", 2f);
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.CompareTag("Wall")||col.gameObject.CompareTag("Zombie")){
            transform.Rotate(0, 0, rotationSpeed);
        }
        

    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Wall")||col.gameObject.CompareTag("Zombie")){
            isRotating = false;
            animator.SetFloat("isWalking", 1f);
        }
        if(col.gameObject.CompareTag("Player")){
            isAttacking = false;
            animator.SetFloat("isWalking", 2f);
        }
    }

    void MoveForward(){
        rigidBody.position += new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;        
        
    }

    void Update()
    {   
        if(player.GetComponent<PlayerHealth>().animating && healthBar.activeSelf == false && player.GetComponent<PlayerHealth>().canAttack){
            healthBar.SetActive(true);
        }
        else if (player.GetComponent<PlayerHealth>().animating==false && healthBar.activeSelf){
            healthBar.SetActive(false);
        }
        if(isRotating == false && isAttacking == false){
            MoveForward();
        }
        if(isAttacking){
            player.GetComponent<PlayerHealth>().hitpoint -= damage * Time.deltaTime;
        }
        if(hitpoint <= 0){
            movementSpeed = 0f;
            animator.SetFloat("isWalking", 0f);
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a - Time.deltaTime);
            if(renderer.color.a <= 0){
                Destroy(gameObject);
            }
        }
        healthBar.transform.localPosition = new Vector3(healthBar.transform.localPosition.x, - (100 - hitpoint)/200 * 1.5f , 0);
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x, 1.5f * hitpoint/100, 1);
    }
    

}
