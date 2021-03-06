﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornShooting : MonoBehaviour {
    //public Vector3 localPos;

    public GameObject player;
    public GameObject enemyBullet;

    public Transform shotspawn;
    
    public bool bulletShot = false;

    public float timer;
    public float cTShoot;


    void Start(){
        player = GameObject.Find("Player");
        shotspawn = GetComponent<Transform>().Find("Shotspawn");
    }

    void Update() {
        Vector3 targetDirection = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDirection);

        timer += Time.deltaTime;
        if (timer >= cTShoot) {

            if (bulletShot == false) {
                bulletShot = true;
                GameObject clone = Instantiate(enemyBullet, shotspawn.position, shotspawn.rotation);
                GetComponent<EnemyBehaviour>().RegisterBullet(clone);
                //clone.transform.position = shotspawn.transform.position;
                //clone.transform.rotation = targetRotation;
            }
        }
    }
}
