using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customCursor : MonoBehaviour
{
    public Texture2D cursorSprite; // Your custom cursor sprite
    public Vector2 hotspot = Vector2.zero; // The point in the sprite that will be the cursor's click point
    public CursorMode cursorMode = CursorMode.Auto;
    AudioManager audioManager;
    public Transform tRaNsFoRm;
    public Transform finalPosn;
    public GameObject escape;
    public AudioClip LastSound;
    public float speed;
    bool run = false;
    void Start()
    {
        run = false;
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        Cursor.SetCursor(cursorSprite, hotspot, cursorMode);
    }

    public void TurnOn()
    {
        run = true;
        audioManager.Door.PlayOneShot(LastSound);
    }

    void Update()
    {
        if(run)
        {
            escape.SetActive(true);
            tRaNsFoRm.position += new Vector3(0f, -speed * Time.deltaTime,0f);
            if(finalPosn.position.y > tRaNsFoRm.position.y){
                run = false;
            }
        }
    }
}
