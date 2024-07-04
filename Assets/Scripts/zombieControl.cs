using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class zombieControl : MonoBehaviour
{
    bool facingplayer;
    Camera MainCamera;
    Animator animator;
    AudioSource playerAudio;
    public bool isAttacked;
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
    AudioManager audioManager;
    AudioSource audioSource;
    int NumberOfRoarClips;
    bool DeathAudioPlayed;
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
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        NumberOfRoarClips = audioManager.Zombie_roar.Count;
        MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
        DeathAudioPlayed = false;
        isAttacked = false;
        facingplayer = false;
        playerAudio = GameObject.FindWithTag("MainCamera").transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        if(rnd.Next(0,100)<50){
                rotationSpeed *= -1;
            }
        transform.Rotate(0, 0, 90f * rnd.Next(0, 4));
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Wall")||col.gameObject.CompareTag("Zombie")){
            isRotating = true;
            if(animator == null){Debug.Log("Animator NOT Working");}
            animator.SetFloat("isWalking", 0f);
        }
        if(col.gameObject.CompareTag("Player")){
            Vector2 A = new Vector2(transform.right.x,transform.right.y);
            Vector2 B = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 C = new Vector2(transform.position.x, transform.position.y);
            B = (B-C);
            if(B.x * A.x + B.y * A.y > 0)
            {
                isAttacking = true;
                animator.SetFloat("isWalking", 2f);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.CompareTag("Wall")||col.gameObject.CompareTag("Zombie") && isRotating){
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
            animator.SetFloat("isWalking", 1f);
        }
    }

    void MoveForward(){
        rigidBody.position += new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;        
        
    }
    

    void Update()
    {   
        if(player.GetComponent<playerMovement>().paused)
        {
            transform.parent.gameObject.SetActive(false);
        }
        if(player.GetComponent<PlayerHealth>().animating && healthBar.activeSelf == false && player.GetComponent<PlayerHealth>().canAttack && isAttacked){
            healthBar.SetActive(true);
        }
        else if (player.GetComponent<PlayerHealth>().animating==false && healthBar.activeSelf){
            healthBar.SetActive(false);
        }
        if(isRotating == false && isAttacking == false){
            MoveForward();
        }
        if(isAttacking){
            Debug.Log("Zombie Attacking");
            player.GetComponent<PlayerHealth>().hitpoint -= damage * Time.deltaTime;
            if(playerAudio.isPlaying == false){
                playerAudio.PlayOneShot(audioManager.PlayerHurt);
            }
            
        }
        if(hitpoint <= 0){
            movementSpeed = 0f;
            animator.SetFloat("isWalking", 0f);
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a - Time.deltaTime);
            if(renderer.color.a <= 0){
                Destroy(gameObject);
                player.GetComponent<PlayerHealth>().kills += 1;
            }
            if(DeathAudioPlayed = false)
            {
                audioSource.PlayOneShot(audioManager.ZombieDeath);
                DeathAudioPlayed = true;
            }
        }
        Vector3 ViewLocation = MainCamera.WorldToViewportPoint(transform.position);
        if(ViewLocation.x < 1 && ViewLocation.x > 0 && hitpoint > 0)
        {
            if(ViewLocation.y < 1 && ViewLocation.y > 0)
            {
                if(audioSource.isPlaying == false)
                {
                    audioSource.PlayOneShot(audioManager.Zombie_roar[rnd.Next(NumberOfRoarClips)]);
                }
            }
        }
        healthBar.transform.localPosition = new Vector3(healthBar.transform.localPosition.x, - (100 - hitpoint)/200 * 1.5f , 0);
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x, 1.5f * hitpoint/100, 1);
    }
    

}
