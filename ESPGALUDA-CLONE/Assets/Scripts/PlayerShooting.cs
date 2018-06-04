using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject shot;
    public GameObject laser;
    public GameObject laser1;

    public Transform shotSpawn;
    public Transform shotSpawn1;

    LineRenderer[] lasers;

    public float fireRate;
    public float laserRate;
    public float laserfireRate;
    public float maxLaserDistance;
    public float laserTimer;
    public float laserTimerSpeed;
    private float nextFire;

    //public bool powerup1;
    public bool LaserON = false;

    //private LineRenderer laserRenderer;

    public string bulletAudioEvent;

    public PlayerMovement play;

    void Start() {
        play = FindObjectOfType<PlayerMovement>();
    }

    public bool MovementSlowdown() {
        return laserTimer >= 2; // TODO
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire2")) {
            if (GameManager.instance.gameState == GameState.Normal) {
                if (play.Crystals >= 25) {
                    GameManager.instance.gameState = GameState.Kakusei;
                } else {
                    GameManager.instance.gameState = GameState.KakuseiOver;
                }
            } else {
                GameManager.instance.gameState = GameState.Normal;
            }
        }

        //if (Input.GetButtonDown("Fire2")) {
        //    if (play.Crystals >= 25) {
        //        GameManager.instance.gameState = (GameManager.instance.gameState == GameState.Normal) ? GameState.Kakusei : GameState.Normal;
        //        //GameManager.instance.gameState = GameManager.instance.gameState;
        //    } else if {

        //    }
        //}
        //if (play.Crystals <= 0) {
        //    if (GameManager.instance.gameState == GameState.Kakusei) {
        //        if (Input.GetButtonDown("Fire2")) {
        //            GameManager.instance.gameState = GameState.KakuseiOver;
        //        }
        //    }
        //}


        //if(GameManager.instance.kakusei && Input.GetButtonDown("Fire1"))
        //{
        //    laserRenderer.enabled = true;
        //}

        if (Input.GetButtonUp("Fire1")) {
            foreach (var laserRenderer in lasers) {
                laserRenderer.enabled = false;
            }
            laserTimer = 0;
            nextFire = Time.unscaledTime + fireRate;
        }

        if (Input.GetButton("Fire1")) {

            if (laserTimer >= 2) {
                laserTimer = 2;
                //nextFire = Time.unscaledTime + 10;
                int enemyLayerMask = LayerMask.GetMask("Enemy", "Flying Enemies", "Ground Enemies");
                foreach (var laserRenderer in lasers) {

                    RaycastHit hit;
                    if (Physics.Raycast(laserRenderer.transform.transform.position, Vector3.forward, out hit, maxLaserDistance, enemyLayerMask)) {
                        // todo: piirrä säde viholliseen asti
                        GameObject enemy = hit.collider.gameObject;
                        enemy.GetComponent<EnemyBehaviour>().TakeDamage(4 * Time.unscaledDeltaTime);
                        laserRenderer.SetPosition(1, Vector3.forward * (enemy.transform.position - transform.position).z);
                    } else {
                        // todo: piirrä riittävän pitkä säde
                        laserRenderer.SetPosition(1, Vector3.forward * maxLaserDistance);
                        Physics.Raycast(shotSpawn.transform.position, transform.forward * 100, enemyLayerMask);
                        // Debug.DrawLine(Vector3.zero, new Vector3(0,0,100), Color.red);
                    }
                    laserRenderer.enabled = true;
                }        
            } else if (Time.unscaledTime > nextFire) {
                //GameManager.instance.kakusei = false;
                GameObject clone;
                clone = Instantiate(shot);
                clone.transform.position = shotSpawn.transform.position;
                //clone.GetComponent<BulletMover>().playfieldCenter = playfieldCenter;
                //clone.GetComponent<BulletMover>().localPos = GetComponent<PlayerMovement>().localPos;
                Fabric.EventManager.Instance.PostEvent(bulletAudioEvent);
                nextFire = Time.unscaledTime + fireRate;
                //GetComponent<AudioSource>().Play();
                laserTimer += Time.unscaledDeltaTime * laserTimerSpeed;

            }
        }



            if (Input.GetButtonDown("X360_RBumper")) {
            GameObject clone;
            clone = Instantiate(shot) as GameObject;
            nextFire = Time.unscaledTime + fireRate;

            clone.transform.position = shotSpawn.transform.position;
            //GetComponent<AudioSource>().Play();
        }
        // LaserGunShot();
    }

    void Awake() {
        shotSpawn = transform.Find("ShotSpawn");
        shotSpawn1 = transform.Find("ShotSpawn1");
        lasers = GetComponentsInChildren<LineRenderer>();
        //laserRenderer = GetComponentsInChildren<LineRenderer>();
    }

    //public void GunAdd() {
    //    if (Input.GetButton("Fire1") && Time.unscaledTime > nextFire) {
    //        GameObject clone1;
    //        clone1 = Instantiate(shot) as GameObject;
    //        nextFire = Time.unscaledTime + fireRate;

    //        clone1.transform.position = shotSpawn1.transform.position;
    //    }

    //}

    //public void LaserGunShot() {
    //    //if (Input.GetKey("Fire1") && Time.time > nextFire)
    //    if (Input.GetKey(KeyCode.Mouse2) && Time.unscaledTime > nextFire) {
    //        GameObject clone2;
    //        clone2 = Instantiate(laser) as GameObject;
    //        LaserON = true;
    //        nextFire = Time.unscaledDeltaTime + laserfireRate;
    //        clone2.transform.position = shotSpawn1.transform.position;

    //        //localPos = localPos + transform.forward * Time.deltaTime * speed;
    //        // clone2.transform.position = transform.position += Vector3.forward * Time.deltaTime;
    //    }

    //    if (Input.GetKeyUp(KeyCode.Mouse2)) {
    //        LaserON = false;
    //    }
    //}
}
