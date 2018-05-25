using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : EnemyBehaviour {


    public GameObject target;
    public GameObject shot;
    public GameObject shotSpawn;
    private float nextFire;
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
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDirection);
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * 180);

        float currentFireRate = (GameManager.instance.kakusei) ? kakuseiFireRate : fireRate;

        if (Time.time > nextFire) {
            GameObject clone = Instantiate(shot);

            nextFire = Time.time + currentFireRate;

            clone.transform.position = shotSpawn.transform.position;
            clone.transform.rotation = targetRotation;
            //Fabric.EventManager.Instance.PostEvent(bulletAudioEvent);
            //GetComponent<AudioSource>().Play();
        }
    }
}
