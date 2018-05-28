using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShooting : MonoBehaviour{

    public Transform player;
    public Transform shotspawn;
    public GameObject enemyBullet;
    public float bulletShot = 0;

    void Start(){
        player = GameManager.instance.player.transform;
        shotspawn = GetComponent<Transform>().Find("Shotspawn");


    }

    void Update(){
        Vector3 targetDirection = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDirection);

       // if(transform.position == )
        {
            while(bulletShot < 7)
            {
                GameObject clone = Instantiate(enemyBullet, shotspawn.position, shotspawn.rotation);
                bulletShot++;
            }
        }
    }

}
