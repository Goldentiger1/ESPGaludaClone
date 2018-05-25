using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject shot;
    public GameObject laser;
    public Transform shotSpawn;
    public Transform shotSpawn1;
    public float fireRate;
    public float laserRate;
    public float laserfireRate;
    public bool LaserON = false;
    public float maxLaserDistance;

    public bool powerup1;

    private float nextFire;
    private LineRenderer laserRenderer;

    public string bulletAudioEvent;



    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire2"))
        {
            GameManager.instance.kakusei = true;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            GameManager.instance.kakusei = false;
        }

        //if(GameManager.instance.kakusei && Input.GetButtonDown("Fire1"))
        //{
        //    laserRenderer.enabled = true;
        //}

        if(Input.GetButtonUp("Fire1") || !GameManager.instance.kakusei)
        {
            laserRenderer.enabled = false;
        }

        if (Input.GetButton("Fire1"))
        {
            if(GameManager.instance.kakusei)
            {
                int enemyLayerMask = 1 << 9;
                RaycastHit hit;
                if (Physics.Raycast(shotSpawn.transform.position, Vector3.forward, out hit, maxLaserDistance, enemyLayerMask))
                {
                    // todo: piirrä säde viholliseen asti
                    GameObject enemy = hit.collider.gameObject;
                    enemy.GetComponent<EnemyBehaviour>().TakeDamage(2 * Time.deltaTime);
                    laserRenderer.SetPosition(1, Vector3.forward * (enemy.transform.position - transform.position).z);
                }
                else
                {
                    // todo: piirrä riittävän pitkä säde

                    laserRenderer.SetPosition(1, Vector3.forward * maxLaserDistance);   
                    Physics.Raycast(shotSpawn.transform.position,transform.forward * 100,enemyLayerMask);
                    // Debug.DrawLine(Vector3.zero, new Vector3(0,0,100), Color.red);
                }
                laserRenderer.enabled = true;
            }
            else if (Time.time > nextFire)
            {
                //GameManager.instance.kakusei = false;
                GameObject clone;
                clone = Instantiate(shot);
                clone.transform.position = shotSpawn.transform.position;
                //clone.GetComponent<BulletMover>().playfieldCenter = playfieldCenter;
                //clone.GetComponent<BulletMover>().localPos = GetComponent<PlayerMovement>().localPos;
                Fabric.EventManager.Instance.PostEvent(bulletAudioEvent);
                nextFire = Time.time + fireRate;
                //GetComponent<AudioSource>().Play();
            }
        }

           
            
        if (Input.GetButtonDown("X360_RBumper")) {
            GameObject clone;
            clone = Instantiate(shot) as GameObject;
            nextFire = Time.time + fireRate;

            clone.transform.position = shotSpawn.transform.position;
            //GetComponent<AudioSource>().Play();
        }
       // LaserGunShot();
    }

    void Awake() {
        shotSpawn = transform.Find("ShotSpawn");
        shotSpawn1 = transform.Find("ShotSpawn1");
        laserRenderer = GetComponentInChildren<LineRenderer>();
    }

    public void GunAdd() {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            GameObject clone1;
            clone1 = Instantiate(shot) as GameObject;
            nextFire = Time.time + fireRate;

            clone1.transform.position = shotSpawn1.transform.position;
        }

    }

    public void LaserGunShot()
    {
        //if (Input.GetKey("Fire1") && Time.time > nextFire)
        if (Input.GetKey(KeyCode.Mouse2) && Time.time > nextFire)

        {
            GameObject clone2;        
            clone2 = Instantiate(laser) as GameObject;
            LaserON = true;
            nextFire = Time.deltaTime + laserfireRate;
            clone2.transform.position = shotSpawn1.transform.position;

            //localPos = localPos + transform.forward * Time.deltaTime * speed;
            // clone2.transform.position = transform.position += Vector3.forward * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Mouse2)) 
        {
            LaserON = false;
        }
    }
}
