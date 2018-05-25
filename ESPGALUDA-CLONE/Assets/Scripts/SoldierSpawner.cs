using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour{

    public GameObject soldierEnemy;

    private Transform soldierTrigger;
    public Transform spawnPoint;
    public Transform[] waypoints;
    int currentWaypoint = 0;

    float timer;
    public float tickTime;

    void Start(){

        soldierTrigger = GameObject.Find("SoldierTrigger").GetComponent<Transform>();

        foreach(Transform child in soldierTrigger){
            if (child.name == "Spawnpoint"){
                continue;
            }
            //waypoints[currentWaypoint] = child.
            }
        }       
        
        /*
        waypoints = transform.GetComponentsInChildren<Transform>();
        spawnPoint = waypoints[1];
        currentWaypoint = 2;
        */
    

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

