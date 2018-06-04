using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

    public Transform spawnpoint;
    public GameObject boss;
    public bool spawned = false;

    void Start()
    {
        spawnpoint = GameObject.Find("BossSpawner").GetComponent<Transform>();
    }

    void Update()
    {
        if (spawned == false)
        {
            var clone = Instantiate(boss, spawnpoint.position, Quaternion.identity);
            spawned = true;
        }
    }

}
