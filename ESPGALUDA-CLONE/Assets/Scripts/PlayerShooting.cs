using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    public string bulletAudioEvent;

    // Update is called once per frame
    void Update ()
    {
        {

            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                GameObject clone;
                clone = Instantiate(shot) as GameObject;
                nextFire = Time.time + fireRate;

                clone.transform.position = shotSpawn.transform.position;
                Fabric.EventManager.Instance.PostEvent(bulletAudioEvent);
                //GetComponent<AudioSource>().Play();
            }
            if (Input.GetButtonDown("X360_RBumper"))
            {
                GameObject clone;
                clone = Instantiate(shot) as GameObject;
                nextFire = Time.time + fireRate;

                clone.transform.position = shotSpawn.transform.position;
                //GetComponent<AudioSource>().Play();
            }
        }
    }

    void Awake() {
        shotSpawn = transform.Find("ShotSpawn");
        


    }

}
