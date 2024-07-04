using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public Vector3 playerVector3;
    public float playerHitpoints;
    public int playerAmmos;
    public int kills;
    public bool generatorRunning;
    public List<Vector3> zombieVector3;
    public List<float> zombieHitPoint;

    //TO-DO : ADD COLLECTIBLES ALSO
    public List<Vector3> healthBoostVector3;
    public List<Vector3> bulletsTransfrom;
    public bool Loading = false;

    public GameData()
    {
        zombieVector3 = new List<Vector3>();
        zombieHitPoint = new List<float>();
        healthBoostVector3 = new List<Vector3>();
        bulletsTransfrom = new List<Vector3>();
    }
}
