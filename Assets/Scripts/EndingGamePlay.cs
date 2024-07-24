using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EndingGamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameOver;
    public float speed;
    public GameObject GameOver;
    public GameObject player;
    string path ;
    public Transform Zombies;
    void Start()
    {
        GameOver.SetActive(false);
        gameOver = false;   
        path = Application.persistentDataPath + "/savefile.json";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameOver = true;
        }
    }
    void Update()
    {
        if(player.activeSelf)
        {
            if(player.GetComponent<PlayerHealth>().hitpoint <= 0)
            {
                gameOver = true;
                GameOver.SetActive(true);
                Debug.Log(gameObject);
                int m = 0;
                foreach(Transform child in Zombies)
                {
                    if(m>0)
                    {
                        Destroy(child.gameObject);
                    }
                    m+=1;
                }

            }
            if(gameOver)
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                gameObject.SetActive(false);
                Debug.Log(gameObject.activeSelf);
                if(player.GetComponent<PlayerHealth>().hitpoint > 0)  
                {
                    player.transform.position = transform.position;
                    player.transform.localScale -= new Vector3(1, 1, 1) * speed * Time.deltaTime;
                }
                if(player.transform.localScale.x <= 0)
                {
                    gameOver = false;
                    Debug.Log("Game Over");
                    //

                }
            }
        }
    }
}
