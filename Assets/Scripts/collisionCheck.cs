using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionCheck : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggered");
        if(col.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }
}
