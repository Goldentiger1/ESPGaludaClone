using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public Transform shotSpawn1;
    public float fireRate;

    public bool powerup1;

    private float nextFire;

    public string bulletAudioEvent;

    // Update is called once per frame
    void Update() {
        {

            if (Input.GetButton("Fire1") && Time.time > nextFire) {
                GameObject clone;
                clone = Instantiate(shot);
                clone.transform.position = shotSpawn.transform.position;
                //clone.GetComponent<BulletMover>().playfieldCenter = playfieldCenter;
                //clone.GetComponent<BulletMover>().localPos = GetComponent<PlayerMovement>().localPos;
                Fabric.EventManager.Instance.PostEvent(bulletAudioEvent);
                nextFire = Time.time + fireRate;
                //GetComponent<AudioSource>().Play();
            }
            if (Input.GetButtonDown("X360_RBumper")) {
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

    public void GunAdd() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            GameObject clone1;
            clone1 = Instantiate(shot) as GameObject;
            nextFire = Time.time + fireRate;

            clone1.transform.position = shotSpawn1.transform.position;
        }

    }
}
