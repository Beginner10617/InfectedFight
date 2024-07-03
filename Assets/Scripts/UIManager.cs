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
    AudioManager audioManager;
    public AudioClip click_sound;
    cameraManager manager;
    void Start()
    {
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
        if(Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1)||Input.GetMouseButtonDown(2))
        {
            audioManager.Door.PlayOneShot(click_sound);
        }
    }
}
