using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShipController : EnemyBehaviour {

    public GameObject gunship;
    public GameObject shot;
    public GameObject shotSpawn;
    public PlayerMovement player;
    public float speed;
    public float leaveScreen;
    public Vector3 localPos;
    private float nextFire;
    bool inPosition;
    public Vector3 target;

    float timer;


    void Start()
    {
        localPos = transform.position - World.center.position;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        inPosition = false;
    }

    void Update(){

        if (inPosition == false){
            float movement = speed * Time.deltaTime;
            localPos = Vector3.MoveTowards(localPos, target, movement);
            transform.position = World.center.position + localPos;

            if (Vector3.Distance(localPos, target) < 0.01f) {
                inPosition = true;
            } else {
                transform.rotation = Quaternion.LookRotation(target - localPos);
            }
        } else {
            Vector3 targetDirection = player.transform.position - transform.position;
            targetDirection.y = 0;
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * 180);


            if (Time.time > nextFire){
                GameObject clone = Instantiate(shot);

                RegisterBullet(clone);

                nextFire = Time.time + fireRate;

                clone.transform.position = shotSpawn.transform.position;
                clone.transform.rotation = targetRotation;
            }
        }
    }
}
