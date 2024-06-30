using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Audio Sources")]
    public AudioSource Background;
    public AudioSource Player;
    public AudioSource Door;
    public AudioSource Weapon;
    [Header("Audio Clips")]
    public AudioClip walk1;
    public AudioClip gunFire;
    public AudioClip knife;
    public List<AudioClip> Zombie_roar;
    public AudioClip ZombieDeath;
    public AudioClip PlayerHurt;
    public AudioClip PlayerDeath;
    System.Random rnd;
    void Start()
    {
        rnd = new System.Random();
    }
    public void PlayerPlayAudio(AudioClip input){
        Player.PlayOneShot(input);
    }

    public void WeaponPlayAudio(AudioClip input){
        Weapon.PlayOneShot(input);
    }
    

}
