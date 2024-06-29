using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artifact : MonoBehaviour
{
    public GameObject Artifact;
    bool isPlayer;
    void Start()
    {
        isPlayer = false;
        Artifact.SetActive(false);
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayer = true;
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(isPlayer)
        {
//            Debug.Log("isPlayer")
            if(Input.GetKey(KeyCode.Tab))
            {
                Artifact.SetActive(true);
            }
            else
            {
                Artifact.SetActive(false);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
