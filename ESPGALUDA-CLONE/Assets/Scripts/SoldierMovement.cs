﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : EnemyBehaviour{

    public float speed;
    //public List<GameObject> waypoints = new List<GameObject>();
    public Vector3 target;



    void Start(){
        //waypoints = GetComponentInChildren<GameObject>();
    }

    void Update(){
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, movement);
    }
}
