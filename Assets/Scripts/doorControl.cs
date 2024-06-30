using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    public float speed;
    public float displace;
    public Transform childTransform;
    Vector3 originalLocation = new Vector3();
    AudioManager audioManager;
    public AudioClip doorSound;
    bool playAudio;
    bool open = false;

    void Start()
    {
        open = false;
        playAudio = false;
        originalLocation = childTransform.position;
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            open = true;
            playAudio = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            open = false;
        }
    }
    // Update is called once per frame
    void Open()
    {
        if(childTransform.position.x < originalLocation.x + displace)
        {
            childTransform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }  

    void Close()
    {
        if(childTransform.position.x > originalLocation.x)
        {
            childTransform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }
    void OnTriggerStay2D()
    {
        if(open)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Update()
    {
        if(!open)
        {
            Close();
        }
        else if (playAudio)
        {
            if(!audioManager.Door.isPlaying)
            {
                audioManager.Door.PlayOneShot(doorSound);
                playAudio = false;
            }
        }
    }
}
