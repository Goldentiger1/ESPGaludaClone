using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{

    public GameObject soldierEnemy;

    private GameObject soldierTrigger;
    public Transform spawnPoint;
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    private int count = 0;

    private float timer;
    public float tickTime;

    void Start()
    {
        // To-Do Fix code there could be many more soldier triggers.
        soldierTrigger = this.gameObject;

        foreach (Transform child in soldierTrigger.transform)
        {

            if (child.name == "Spawnpoint")
            {
                currentWaypoint--;
                continue;
            }
            waypoints[count] = transform.GetChild(currentWaypoint);
            currentWaypoint++;
            count++;
        }
    }

    /*waypoints = transform.GetComponentsInChildren<Transform>();
     * spawnPoint = waypoints[1];
     * currentWaypoint = 2;
     */

    void Update()
    {

        if (currentWaypoint < waypoints.Length)
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

