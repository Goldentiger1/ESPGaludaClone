using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{

    public GameObject soldierEnemy;

    private GameObject soldierTrigger;
    public Transform spawnPoint;
    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    private int count = 0;

    private float timer;
    public float tickTime;

    void Start()
    {
        waypoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (child.name.ToLower() != "spawnpoint")
            {
                waypoints.Add(child);
            }
        }
    }

    /*waypoints = transform.GetComponentsInChildren<Transform>();
     * spawnPoint = waypoints[1];
     * currentWaypoint = 2;
     */

    void Update()
    {

        if (currentWaypoint < waypoints.Count)
        {
            timer += Time.deltaTime;

            while (timer > tickTime)
            {
                var enemy = Instantiate(soldierEnemy, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<SoldierMovement>().target = waypoints[currentWaypoint].position;
                timer -= tickTime;
                currentWaypoint++;
            }
        }
    }
}

