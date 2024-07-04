using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{    
    public Texture2D cursorSprite; // Your custom cursor sprite
    public Vector2 hotspot = Vector2.zero; // The point in the sprite that will be the cursor's click point
    public CursorMode cursorMode = CursorMode.Auto;
    public List<GameObject> ToStart;
    public GameObject LoadingScreen;
    public GameObject Pause;
    AudioManager audioManager;
    public AudioClip click_sound;
    cameraManager manager;
    Vector3 startingPoint;
    void Start()
    {
        startingPoint = new Vector3(1.5f, -79, -1);
        LoadingScreen.SetActive(false);
        Cursor.SetCursor(cursorSprite, hotspot, cursorMode);
        manager = GameObject.FindWithTag("MainCamera").GetComponent<cameraManager>();
        manager.enabled = false;
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
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
        LoadingScreen.SetActive(false);
    }
    public void Play()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
//        LoadingScreen.SetActive(true);
        Invoke("StartGame", 3f);
    }

    public void ResetPlayerPosition()
    {
        
    }

    public void ShowControls()
    {}

    public void Credits()
    {}

    public void Quit()
    {}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1)||Input.GetMouseButtonDown(2))
        {
            audioManager.Door.PlayOneShot(click_sound);
        }

    }

    public void Resume()
    {
        GameObject.FindWithTag("Player").GetComponent<playerMovement>().paused = false;
        Pause.SetActive(false);
        StartGame();
    }

    public void Exit()
    {
        manager.enabled = false;
        GameObject.FindWithTag("Player").GetComponent<playerMovement>().paused = false;
        GameObject.FindWithTag("Player").SetActive(false);
        int n=0;
        foreach(GameObject gO in ToStart)
        {
            if(n==1)
            {
                int m=0;
                foreach(Transform child in gO.transform)
                {
                    if(m>0) Destroy(child.gameObject);
                    m+=1;
                }
            }
            n+=1;
            gO.SetActive(false);
        }
        Pause.SetActive(false);
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        LoadingScreen.SetActive(false);
        
    }
}
