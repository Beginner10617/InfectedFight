using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer renderer;
    public float rotationSpeed = 5f;
    bool present;
    void Start()
    {
        present = true;
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Player")){
            present = false;
            col.gameObject.GetComponent<PlayerHealth>().handGunAcquired = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(present == false){
            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a - Time.deltaTime);
            if(renderer.color.a <= 0){
                Destroy(gameObject);
            }
        }
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}