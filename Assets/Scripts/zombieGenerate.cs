using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieGenerate : MonoBehaviour
{
    Transform TransformsOfZombie;
    System.Random rnd;
    public int number_of_zombies;
    public GameObject Zombie;
    public bool running = false;
    public AudioClip announce;
    AudioManager audioManager;
    public GameData gameData;
    // Start is called before the first frame update
    public void Start()
    {
        gameData = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().gameData;
        rnd = new System.Random();
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        TransformsOfZombie = transform.GetChild(0);
        if(gameData.Loading)
        {
            LoadZombies();
        }
    }
public void LoadZombies()
{
    gameData = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().gameData;
    int m=0;
    foreach(Transform child in transform)
    {
        if(m>0) Destroy(child.gameObject);
        m+=1;
    }
    Debug.Log(gameData.zombieVector3.Count);
    for(int i=0; i<gameData.zombieVector3.Count; i++)
    {
        //(gameData.zombieVector3[i]);
        GameObject zombie = Instantiate(Zombie, gameData.zombieVector3[i], Quaternion.identity, transform);
        zombie.GetComponent<zombieControl>().hitpoint = gameData.zombieHitPoint[i];
    }
    running = gameData.generatorRunning;

}
public void Generate()
{            
    //Debug.Log(TransformsOfZombie);
    foreach(Transform Row in TransformsOfZombie)
    {
        float y = Row.position.y;
        foreach(Transform child in Row)
        {
            float x = child.position.x;
            Instantiate(Zombie, new Vector3(x, y, 0f), Quaternion.identity, transform);
        }
    }
    running = true;
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
