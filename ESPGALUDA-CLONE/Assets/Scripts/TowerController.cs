using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour, IEnemy {

    private const float GOLDEN_RATIO = 1.61803399f; // https://www.youtube.com/watch?v=sj8Sg8qnjOg

    public GameObject target;
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;
    private float nextFire;
    public float hitpoints;
    public GameObject Crystal;


    public void TakeDamage(float dmg) {
        hitpoints -= dmg;
        if (hitpoints < 0) {
            Destroy(gameObject);
            for (int i = 0; i < 10; i++) {
                float radius = Mathf.Log(i + 1, 2); // distance from center
                float angle = ((i * GOLDEN_RATIO) % 1) * 2 * Mathf.PI; // direction of offset in radians
                Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
                Instantiate(Crystal, transform.position + offset, Quaternion.identity);
            }
        }
    }

    void Update () {
        Vector3 targetDirection = target.transform.position - transform.position;
        targetDirection.y = 0;
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDirection);
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * 180);

        if (Time.time > nextFire){
            GameObject clone = Instantiate(shot);

            nextFire = Time.time + fireRate;

            clone.transform.position = shotSpawn.transform.position;
            clone.transform.rotation = targetRotation;
            //Fabric.EventManager.Instance.PostEvent(bulletAudioEvent);
            //GetComponent<AudioSource>().Play();
        }
    }
}
