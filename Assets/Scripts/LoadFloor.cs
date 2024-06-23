using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFloor : MonoBehaviour
{
    GameObject tile;
    public GameObject Player;
    public GameObject Zombies;
    float i, j;
    bool stop;
    void Start()
    {
        tile = transform.GetChild(0).gameObject;
        tile.SetActive(false);
        Player.SetActive(false);
        Zombies.SetActive(false);
        i = -80; j = -80;
    }

    // Update is called once per frame
    void Update()
    {
        if(stop==false)
        {
            //change
            if(i>80){
                if(j>80){stop = true;}
                i = -80; j+= 1;
            }
            else{
                i+=1f;
            }
            //instantiate
            Instantiate(tile, new Vector3(i, j, 1), Quaternion.identity, transform).SetActive(true);

        }
        else{

            Player.SetActive(true);
            Zombies.SetActive(true);
            Destroy(this);
        }
    }
}
