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
    GameData gameData;
    public GameObject Zombies;
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
        gameData = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().gameData;

        if(!gameData.Loading) 
        {
            Zombies.GetComponent<zombieGenerate>().Generate();
        }
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
        Zombies.SetActive(true);
     //   StartGame();
    }

    public void Exit()
    {
        //Restarting player
        GameObject.FindWithTag("Player").transform.position = startingPoint;
        GameObject.FindWithTag("Player").SetActive(false);

        //Restarting Zombies
        while(true)
        {
            GameObject x = GameObject.FindWithTag("Zombie");
            if(x==null)
            {
                break;
            }
            else
            {
                Destroy(x);
            }
        }
    }
}
