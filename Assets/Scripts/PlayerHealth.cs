using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    GameObject UpperBody;
    GameObject Zombie;
    public float hitpoint;
    Animator animator;
    bool canAttack;
    public bool animating;
    public float damage;// damage per second
    
    void Start()
    {        
        UpperBody = GameObject.FindWithTag("UpperBody");
        if (UpperBody == null) {
            Debug.Log("UpperBody not found by camera");
        }
        animator = UpperBody.GetComponent<Animator>();

        canAttack = false;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Zombie")){
            canAttack = true;
            Zombie = col.gameObject;
        }
    }


    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Zombie")){
            canAttack = false;
        }
    }

    void Attack(){
        animating = true;
        UpperBody.transform.localPosition = new Vector3(0.185f, -0.303f, 0f);
        animator.SetFloat("isWalking", 2f);
        
    }

    void stopAttack(){
        animating = false;
        UpperBody.transform.localPosition = new Vector3(0,0,0);
        animator.SetFloat("isWalking", 0f);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && animating == false){
            if(canAttack){
                Zombie.GetComponent<zombieControl>().hitpoint -= damage;
            }
            Attack();
            Invoke("stopAttack", 1);
        }
    }
}
