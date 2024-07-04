using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public UIManager uIManager;
    public Transform Zombies;

    GameObject player;
    void Start()
    {
        gameData = new GameData();
        gameData.Loading=false;
    }
    public void SaveGame()
    {
        gameData = new GameData();
        
            player = GameObject.FindWithTag("Player");
            gameData.playerTransform = player.transform;
            gameData.playerHitpoints = player.GetComponent<PlayerHealth>().hitpoint;
            gameData.playerAmmos = player.GetComponent<PlayerHealth>().ammos;
            foreach(Transform zombie in Zombies)
            {
                gameData.zombieTransform.Add(zombie);
                gameData.zombieHitPoint.Add(zombie.gameObject.GetComponent<zombieControl>().hitpoint);
            }
    

        SaveSystem.SaveGame(gameData);
    }

    public void LoadGame()
    {
        gameData = SaveSystem.LoadGame();
        

        if (gameData == null)
        {
            gameData = new GameData();
            gameData.Loading = false;
            uIManager.Play();
        }
        else
        {
            gameData.Loading = true;
        }
    }

}
