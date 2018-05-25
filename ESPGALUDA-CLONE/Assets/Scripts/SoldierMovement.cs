using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : EnemyBehaviour{

    public float speed;
    //public List<GameObject> waypoints = new List<GameObject>();
    public Vector3 target;
    private Transform player;



    void Start(){
        //waypoints = GetComponentInChildren<GameObject>();
        player = GameManager.instance.player.transform;
    }

    void Update(){
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, movement);

        if(transform.position == target)
        {
            Vector3 targetDirection = player.position - transform.position;
            targetDirection.y = 0;
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * 180);
        }
    }
}
