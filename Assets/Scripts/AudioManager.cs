using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Audio Sources")]
    public AudioSource Background;
    public AudioSource Player;
    public AudioSource Zombie;
    [Header("Audio Clips")]
    public AudioClip walk1;
    public AudioClip walk2;
    public AudioClip gunFire;
    public AudioClip knife;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
