using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : EnemyBehaviour {

    public float speed;
    public Vector3 localPos;
    public List<Transform> waypoints = new List<Transform>();
    Vector3 movingPos;

    void Start(){
        localPos = transform.position - World.center.position;
       // movingPos = waypoints[0].position  - World.center.position;
        
    }

    void Update(){
        float movement = speed * Time.deltaTime;
        localPos = Vector3.MoveTowards(localPos, movingPos, movement);
    }

}
