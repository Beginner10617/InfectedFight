using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public UIManager uIManager;
    public Transform Zombies;
    public Transform healthBoosts;
    public Transform Ammos;
    public GameObject player;
    void Start()
    {
        gameData = new GameData();
        if(gameData==null)
        {
            Debug.Log("Null gameData");
        }
        gameData.Loading=false;
        player.SetActive(true);
    }
    public void SaveGame()
    {
        gameData = new GameData();
        
            gameData.playerVector3 = player.transform.position;
            gameData.playerHitpoints = player.GetComponent<PlayerHealth>().hitpoint;
            gameData.playerAmmos = player.GetComponent<PlayerHealth>().ammos;
            int m=0;
            foreach(Transform zombie in Zombies)
            {
                if(m>0)
                {
                    //(gameData.zombieVector3==null);
                    gameData.zombieVector3.Add(zombie.position);
                    //(zombie==null);
                    gameData.zombieHitPoint.Add(zombie.gameObject.GetComponent<zombieControl>().hitpoint);
                }
                m+=1;
            }
            foreach(Transform health in healthBoosts)
            {
                gameData.healthBoostVector3.Add(health.position);
            }
            foreach(Transform ammo in Ammos)
            {
                gameData.bulletsTransfrom.Add(ammo.position);
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
            Debug.Log("Loading...");
            uIManager.Play();
        }
    }

}
