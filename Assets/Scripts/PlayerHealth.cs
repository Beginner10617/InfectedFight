using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public GameObject UpperBody;
    AudioManager audioManager;
    GameObject Zombie;
    public GameObject healthBar;
    public Transform handgunTransform;
    public float hitpoint;
    public Animator animator;
    public bool canAttack;
    public bool handGunAcquired;
    public bool animating;
    public float knifeDamage;// knifeDamage per second
    public float handGunDamage;
    public float damage;
    public int ammos;
    public TMP_Text bullets;
    
    void Start()
    {        
        handGunAcquired = false;
        UpperBody = GameObject.FindWithTag("UpperBody");
        if (UpperBody == null) {
            Debug.Log("UpperBody not found by camera");
        }
        animator = UpperBody.GetComponent<Animator>();
        damage = knifeDamage;
        canAttack = false;
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        ammos = 0;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Zombie") && handGunAcquired == false){
            canAttack = true;
            Zombie = col.gameObject;
            
        }
    }


    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Zombie") && handGunAcquired == false){
            canAttack = false;
        }
    }

    void KnifeAttack(){
        animating = true;
        if(audioManager.Weapon.isPlaying == false){
            audioManager.WeaponPlayAudio(audioManager.knife);        
        }
        UpperBody.transform.localPosition = new Vector3(0.185f, -0.303f, 0f);
        animator.SetFloat("isWalking", 2f);
        
    }

    void stopAttack(){
        animating = false;
        UpperBody.transform.localPosition = new Vector3(0,0,0);
        animator.SetFloat("isWalking", 0f);
        if(Zombie != null){
            Zombie.GetComponent<zombieControl>().isAttacked = false;
        }
    }
    
    void Shoot(){
        animating = true;
        if(audioManager.Weapon.isPlaying == false){
            audioManager.WeaponPlayAudio(audioManager.gunFire);        
        }
        UpperBody.transform.localPosition = new Vector3(0f, -0.0f, 0f);
        ammos -=1;
        animator.SetFloat("isWalking", 2f);
    }
    void stopShoot(){
        animating = false;
        animator.SetFloat("isWalking", 0f);
        if(Zombie != null){
            Zombie.GetComponent<zombieControl>().isAttacked = false;
        }
    }
    void FixedUpdate()
    {
        if(handGunAcquired)
        {   if(damage != handGunDamage){damage = handGunDamage;}
            float distance = 10f;
            RaycastHit2D hitZombie = Physics2D.Raycast(handgunTransform.position, new Vector2(transform.right.x, transform.right.y));
            Debug.DrawRay(handgunTransform.position, new Vector2(transform.right.x, transform.right.y) * hitZombie.distance, Color.red );
            //drawing Aim
            handgunTransform.GetChild(0).localScale = new Vector3(hitZombie.distance/0.8f, 1f, 1f);
            handgunTransform.GetChild(0).localPosition = new Vector3(hitZombie.distance/1.6f, 0, 0f);
            if(hitZombie.collider.gameObject.CompareTag("Zombie") && canAttack == false && ammos > 0)
            {
                canAttack = true;
                Zombie = hitZombie.collider.gameObject;
            }
            else if (hitZombie.collider.gameObject.CompareTag("Zombie") == false && canAttack)
            {
                canAttack = false;
            }
        }  
        //updating healthBar
        healthBar.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(5 * hitpoint, 25) ;
    }

    void Update()
    {
        bullets.text = ammos.ToString();
        if(Input.GetKeyDown(KeyCode.Space) && animating == false && audioManager.Weapon.isPlaying == false){
            if(canAttack && Zombie != null){
                Zombie.GetComponent<zombieControl>().hitpoint -= damage;
                Zombie.GetComponent<zombieControl>().isAttacked = true;
            }
            if(handGunAcquired && ammos > 0){
                Shoot();
                Invoke("stopShoot", 0.184f);
            }
            else if(handGunAcquired == false){
                KnifeAttack();
                Invoke("stopAttack", 1);
            }
        }
    }
}
