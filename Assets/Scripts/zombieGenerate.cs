using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieGenerate : MonoBehaviour
{
    Transform TransformsOfZombie;
    System.Random rnd;
    public int number_of_zombies;
    public GameObject Zombie;
    bool running = true;
    public AudioClip announce;
    AudioManager audioManager;
    public GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().gameData;
        rnd = new System.Random();
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();

        if(gameData.Loading)
        {
            for(int i=0; i<gameData.zombieTransform.Count; i++)
            {
                GameObject zombie = Instantiate(Zombie, gameData.zombieTransform[i].position, gameData.zombieTransform[i].rotation, transform);
                zombie.GetComponent<zombieControl>().hitpoint = gameData.zombieHitPoint[i];
            }
        }
        else
        {
            TransformsOfZombie = transform.GetChild(0);
            
            foreach(Transform Row in TransformsOfZombie)
            {
                float y = Row.position.y;
                foreach(Transform child in Row)
                {
                    float x = child.position.x;
                    Instantiate(Zombie, new Vector3(x, y, 0f), Quaternion.identity, transform);
                }
            }
        }
    }

    public void StopGenerating()
    {
        running = false;
        if(!audioManager.Door.isPlaying) audioManager.Door.PlayOneShot(announce);
    }

    // Update is called once per frame
    void Update()
    {
        if(running && transform.childCount < number_of_zombies)
        {
            Transform Row = TransformsOfZombie.GetChild(rnd.Next(0, TransformsOfZombie.childCount));
            float y = Row.position.y;
            float x = Row.GetChild(rnd.Next(0, Row.childCount)).position.x;
            Instantiate(Zombie, new Vector3(x, y, 0f), Quaternion.identity, transform);
        }
    }
}
