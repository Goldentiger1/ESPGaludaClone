using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : EnemyBehaviour {


    public GameObject target;
    public GameObject shot;
    public GameObject shotSpawn0;
    public GameObject shotSpawn1;
    public GameObject shotSpawn2;
    public GameObject shotSpawn3;

    private float lastFire;
    //public float hitpoints;
    public GameObject Crystal;



    //public void TakeDamage(float dmg) {
    //    hitpoints -= dmg;
    //    if (hitpoints < 0) {
    //        Destroy(gameObject);
    //        GameManager.CreateCrystals(10, transform);
    //    }
    //}

    void Update() {
        Vector3 targetDirection = target.transform.position - transform.position;
        targetDirection.y = 0;
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * 180);


        float nextFire = lastFire + 1 / (GameManager.instance.gameState == GameState.Kakusei ? kakuseiFireRate : fireRate);

        if (Time.time > nextFire) {
             GameObject clone0 = Instantiate(shot);
            GameObject clone1 = Instantiate(shot);
            GameObject clone2 = Instantiate(shot);
            GameObject clone3 = Instantiate(shot);

            lastFire = Time.time;

            clone0.transform.position = shotSpawn0.transform.position;
            clone0.transform.rotation = targetRotation;

            clone1.transform.position = shotSpawn1.transform.position;
            clone1.transform.rotation = targetRotation;

            clone2.transform.position = shotSpawn2.transform.position;
            clone2.transform.rotation = targetRotation;

            clone3.transform.position = shotSpawn3.transform.position;
            clone3.transform.rotation = targetRotation;
            //Fabric.EventManager.Instance.PostEvent(bulletAudioEvent);
            //GetComponent<AudioSource>().Play();
        }
    }
}
