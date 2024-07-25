using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject UpperBody;
    public GameObject UpperBody2;
    GameObject LowerBody;
    Animator animator;
    Animator feetAnim;
    Rigidbody2D rigidBody;
    public bool enableArrow = true;
    public float movementSpeed = 1.5f;
    public float rotationSpeed = 90f;
    public GameObject Pause;
    public bool paused;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        angle = transform.eulerAngles.z;
        paused = false;
        UpperBody = GameObject.FindWithTag("UpperBody");
        if (UpperBody == null) {
            Debug.Log("UpperBody not found by camera");
        }
        UpperBody2 = GameObject.FindWithTag("UpperBody2");
        if (UpperBody2 == null) {
            Debug.Log("UpperBody2 not found by camera");
        }
        animator = UpperBody.GetComponent<Animator>();
        UpperBody2.SetActive(false);
        LowerBody = GameObject.FindWithTag("LowerBody");
        if (LowerBody == null) {
            Debug.Log("LowerBody not found by camera");
        }
        feetAnim = LowerBody.GetComponent<Animator>();
        rigidBody= GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();

    }

    void MoveForward(){
        rigidBody.position += new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;        
        
            feetAnim.SetFloat("isWalking", 4f);
        if(audioManager.Player.isPlaying == false)
        {
        audioManager.PlayerPlayAudio(audioManager.walk1);
        }
    }
    void MoveBackward(){
        rigidBody.position -= new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;
            feetAnim.SetFloat("isWalking", 4f);
        if(audioManager.Player.isPlaying == false)
        {
        audioManager.PlayerPlayAudio(audioManager.walk1);
        }
    }
    
    void Update()
    {            
        transform.Rotate(0,0,(angle-transform.eulerAngles.z)*Time.deltaTime*10);
            
        if(!paused)
        {
            if(Input.GetKeyDown(KeyCode.Escape)){
                paused = true;
                Debug.Log("Paused");
                Pause.SetActive(true);
            }
            if(GetComponent<PlayerHealth>().handGunAcquired){
                UpperBody.SetActive(false);
                UpperBody2.SetActive(true);
                animator = UpperBody2.GetComponent<Animator>();
            }
            //animations

                if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D)){
                    animator.SetFloat("isWalking", 1f);
                }
                else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)){
                    animator.SetFloat("isWalking", 0f);
                    feetAnim.SetFloat("isWalking", 0f);
                }

                if(Input.GetKey(KeyCode.W)){
                    angle = 90f;
                    MoveForward();
                }
                if(Input.GetKey(KeyCode.S)){
                    //
                    angle = 270f;
                    MoveForward();
                }
                if(Input.GetKey(KeyCode.D)){
                    //
                    angle = 0f;
                    MoveForward();
                }
                if(Input.GetKey(KeyCode.A)){
                    //
                    angle = 180f;
                    MoveForward();
                }
            
        }
    }
}
