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
    public float movementSpeed;
    private float nextFire;

    float timer;


    void Start()
    {
        localPos = transform.position - World.center.position;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update(){
        float movement = speed * Time.deltaTime;

        // rotation ->
        Vector3 targetDirection = player.transform.position - transform.position;
        targetDirection.y = 0;
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDirection);
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
