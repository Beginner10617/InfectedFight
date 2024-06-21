using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Audio Sources")]
    public AudioSource Background;
    public AudioSource Player;
    public AudioSource Weapon;
    public AudioSource Zombie;
    [Header("Audio Clips")]
    public AudioClip walk1;
//    public AudioClip walk2;
    public AudioClip gunFire;
    public AudioClip knife;

    public void PlayerPlayAudio(AudioClip input){
        Player.PlayOneShot(input);
    }

    public void WeaponPlayAudio(AudioClip input){
        Weapon.PlayOneShot(input);
    }
    
    void ZombiePlayAudio(AudioClip input){
        Player.PlayOneShot(input);
    }

}
