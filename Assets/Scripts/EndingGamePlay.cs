using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EndingGamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameOver;
    public float speed;
    GameObject player;
    string path ;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
        if(player.GetComponent<PlayerHealth>().hitpoint <= 0)
        {
            gameOver = true;
        }
        if(gameOver)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            player.transform.position = transform.position;
            player.transform.localScale -= new Vector3(1, 1, 1) * speed * Time.deltaTime;
            if(player.transform.localScale.x <= 0)
            {
                gameOver = false;
                Debug.Log("Game Over");
                //
            }
        }
    }
}
