using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCollectible : MonoBehaviour
{
    public GameData gameData;
    public GameObject HealthBoost;
    public GameObject Ammos;
    Transform healthBoost;
    Transform ammo;
    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().gameData;
        if(gameData.Loading)
        {
            healthBoost = transform.GetChild(0);
            foreach(Transform child in healthBoost)
            {
                Destroy(child.gameObject);
            }
            for(int i=0; i<gameData.healthBoostVector3.Count; i++)
            {
                GameObject collectible = Instantiate(HealthBoost, gameData.healthBoostVector3[i], Quaternion.identity, healthBoost);
            }

            ammo = transform.GetChild(1);
            foreach(Transform child in ammo)
            {
                Destroy(child.gameObject);
            }
            for(int i=0; i<gameData.bulletsTransfrom.Count; i++)
            {
                GameObject collectible = Instantiate(Ammos, gameData.bulletsTransfrom[i], Quaternion.identity, ammo);
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
