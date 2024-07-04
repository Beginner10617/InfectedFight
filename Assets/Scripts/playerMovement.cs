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
    public float movementSpeed = 0.75f;
    public float fastwalkSpeed = 1.5f;
    public float slowwalkSpeed;
    public float strafeSpeed = 0.6f;
    public float rotationSpeed = 90f;
    // Start is called before the first frame update
    void Start()
    {
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
        slowwalkSpeed = movementSpeed;
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();

    }

    void MoveForward(){
        rigidBody.position += new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;        
        if(movementSpeed == slowwalkSpeed){
            feetAnim.SetFloat("isWalking", 1f);
        }
        else if(movementSpeed == fastwalkSpeed){
            feetAnim.SetFloat("isWalking", 4f);
        }
        if(audioManager.Player.isPlaying == false)
        {
        audioManager.PlayerPlayAudio(audioManager.walk1);
        }
    }
    void MoveBackward(){
        rigidBody.position -= new Vector2(transform.right.x, transform.right.y) * movementSpeed * Time.deltaTime;
        if(movementSpeed == slowwalkSpeed){
            feetAnim.SetFloat("isWalking", 1f);
        }
        else if(movementSpeed == fastwalkSpeed){
            feetAnim.SetFloat("isWalking", 4f);
        }
        if(audioManager.Player.isPlaying == false)
        {
        audioManager.PlayerPlayAudio(audioManager.walk1);
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
        feetAnim.SetFloat("isWalking", 2f);     
        if(audioManager.Player.isPlaying == false)
        {
            audioManager.PlayerPlayAudio(audioManager.walk1);
        }
        }
    void StrafeLeft(){
        rigidBody.position += new Vector2(transform.up.x, transform.up.y) * strafeSpeed * Time.deltaTime;
        feetAnim.SetFloat("isWalking", 3f);
        if(audioManager.Player.isPlaying == false)
        {
            audioManager.PlayerPlayAudio(audioManager.walk1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayerHealth>().handGunAcquired){
            UpperBody.SetActive(false);
            UpperBody2.SetActive(true);
            animator = UpperBody2.GetComponent<Animator>();
        }
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
        //animations
        if(enableArrow){
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
                animator.SetFloat("isWalking", 1f);
            }
            else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)){
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 0f);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetFloat("isWalking", 0f);
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetFloat("isWalking", 0f);
                }
            else if(Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow)){
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 0f);
            }
        }
        else{
              if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)){
                animator.SetFloat("isWalking", 1f);
            }
            else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)){
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 0f);
            }
            if(Input.GetKeyDown(KeyCode.A))
            {
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 3f);
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 2f);
            }
            else if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)){
                animator.SetFloat("isWalking", 0f);
                feetAnim.SetFloat("isWalking", 0f);
            }
        }

        //movements
        if(enableArrow){
            if(Input.GetKey(KeyCode.UpArrow)){
                MoveForward();
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                MoveBackward();
            }
            if(Input.GetKey(KeyCode.RightArrow)){
                StrafeRight();
            }
            
            if(Input.GetKey(KeyCode.LeftArrow)){
                StrafeLeft();
            }
        }
        else{
            if(Input.GetKey(KeyCode.W)){
                MoveForward();
            }
            if(Input.GetKey(KeyCode.S)){
                MoveBackward();
            }
            if(Input.GetKey(KeyCode.D)){
                StrafeRight();
            }
            if(Input.GetKey(KeyCode.A)){
                StrafeLeft();
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
