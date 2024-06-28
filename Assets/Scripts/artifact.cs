using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artifact : MonoBehaviour
{
    public GameObject Artifact;
    void Start()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                Artifact.gameObject.SetActive(!Artifact.activeSelf);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
