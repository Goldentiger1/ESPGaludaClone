using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour {

    public float speed;
    public Vector3 localPos;
    public List<Vector3> waypoints = new List<Vector3>();

    void Start(){
        localPos = transform.position - World.center.position;
    }

    void Update(){
        float movement = speed * Time.deltaTime;
        localPos = Vector3.MoveTowards(localPos, waypoints[0], movement);
    }

}
