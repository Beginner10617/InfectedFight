using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingGamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameOver;
    public float speed;
    GameObject player;
    void Start()
    {
        gameOver = false;   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
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
