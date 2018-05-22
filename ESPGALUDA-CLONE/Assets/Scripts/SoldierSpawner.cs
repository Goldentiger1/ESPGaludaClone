using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour{

    public Transform spawnPoint;
    public GameObject soldierEnemy;
    public Transform[] waypoints;

    float timer;
    public float tickTime;
    int currentWaypoint;

    void Start(){
        waypoints = transform.GetComponentsInChildren<Transform>();
        spawnPoint = waypoints[1];
        currentWaypoint = 2;
    }

    void Update() {
        if (currentWaypoint < waypoints.Length) {
            timer += Time.deltaTime;
            while (timer > tickTime) {
                var enemy = Instantiate(soldierEnemy, spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<SoldierMovement>().target = waypoints[currentWaypoint].position;
                timer -= tickTime;
                currentWaypoint++;
            }
        }
    }
}
