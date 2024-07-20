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
    // Start is called before the first frame update
    void Start()
    {
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
    // Update is called once per frame
    void Update()
    {
        if(!paused)
        {
            if(Input.GetKeyDown(KeyCode.P)){
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
                    transform.eulerAngles = new Vector3(0, 0, 90);
                    MoveForward();
                }
                if(Input.GetKey(KeyCode.S)){
                    transform.eulerAngles = new Vector3(0, 0, 270);
                    MoveForward();
                }
                if(Input.GetKey(KeyCode.D)){
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    MoveForward();
                }
                if(Input.GetKey(KeyCode.A)){
                    transform.eulerAngles = new Vector3(0, 0, 180);
                    MoveForward();
                }
            
        }
    }
}
