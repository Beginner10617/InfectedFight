using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> ToStart;
    public GameObject LoadingScreen;
    cameraManager manager;
    void Start()
    {
        manager = GameObject.FindWithTag("MainCamera").GetComponent<cameraManager>();
        manager.enabled = false;
        foreach(GameObject gO in ToStart)
        {
            gO.SetActive(false);
        }
    }

    void StartGame()
    {
        foreach(GameObject gO in ToStart)
        {
            gO.SetActive(true);
        }
        manager.enabled = true;
    }
    public void Play()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        LoadingScreen.SetActive(true);
        Invoke("StartGame", 3f);
    }

    public void Load()
    {}

    public void ShowControls()
    {}

    public void Credits()
    {}

    public void Quit()
    {}

    // Update is called once per frame
    void Update()
    {
        
    }
}
