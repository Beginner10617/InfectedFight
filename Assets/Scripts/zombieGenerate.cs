using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieGenerate : MonoBehaviour
{
    Transform TransformsOfZombie;
    System.Random rnd;
    public int number_of_zombies;
    public GameObject Zombie;
    bool running = true;
    // Start is called before the first frame update
    void Start()
    {
        TransformsOfZombie = transform.GetChild(0);
        rnd = new System.Random();
    }

    void StopGenerating()
    {
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(running && transform.childCount < number_of_zombies)
        {
            Transform Row = TransformsOfZombie.GetChild(rnd.Next(0, TransformsOfZombie.childCount));
            float y = Row.position.y;
            float x = Row.GetChild(rnd.Next(0, Row.childCount)).position.x;
            Instantiate(Zombie, new Vector3(x, y, 0f), Quaternion.identity, transform);
        }
    }
}
