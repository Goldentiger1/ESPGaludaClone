using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject target;
    public GameObject shot;
    public GameObject shotSpawn;
    public float fireRate;
    private float nextFire;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
        Vector3 targetDirection = target.transform.position - transform.position;
        targetDirection.y = 0;
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDirection);
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * 180);

        if (Time.time > nextFire){
            GameObject clone = Instantiate(shot) as GameObject;
            nextFire = Time.time + fireRate;

            clone.transform.position = shotSpawn.transform.position;
            clone.transform.rotation = targetRotation; 
            //Fabric.EventManager.Instance.PostEvent(bulletAudioEvent);
            //GetComponent<AudioSource>().Play();
        }
    }
}
