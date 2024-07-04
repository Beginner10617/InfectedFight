using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public Transform playerTransform;
    public float playerHitpoints;
    public int playerAmmos;
    public int kills;
    public List<Transform> zombieTransform;
    public List<float> zombieHitPoint;
    public bool Loading = false;
}
