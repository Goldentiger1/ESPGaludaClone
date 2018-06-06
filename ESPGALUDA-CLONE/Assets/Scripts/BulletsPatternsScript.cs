using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletPatterns
{
    Nothing,
    Regular,

}

public class BulletsPatternsScript : MonoBehaviour
{
    public BulletPatterns Patterns;
    public Transform bossPosition;
    public Transform playerPosition;
    public bool fired = true;
    public Transform bossGun01;
    public Transform bossGun02;
    public Transform bulletSpawn100;
    public Transform bulletSpawn101;
    public Transform bulletSpawn102;
    public Transform bulletSpawn103;
    public Transform bulletSpawn200;
    public Transform bulletSpawn201;
    public Transform bulletSpawn202;
    public Transform bulletSpawn203;
    public float speed;
    public GameObject bullet;
    public float timer;
    public float timeToShoot = 2;
    private float lastFire;

    void Start()
    {
        bossPosition = GetComponent<Transform>();
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        bossGun01 = GameObject.Find("BossGun1").transform;
        bossGun02 = GameObject.Find("BossGun2").transform;
        bulletSpawn100 = bossGun01.Find("Shotspawn0");
        bulletSpawn101 = bossGun01.Find("Shotspawn1");
        bulletSpawn102 = bossGun01.Find("Shotspawn2");
        bulletSpawn103 = bossGun01.Find("Shotspawn3");
        bulletSpawn200 = bossGun02.Find("Shotspawn0");
        bulletSpawn201 = bossGun02.Find("Shotspawn1");
        bulletSpawn202 = bossGun02.Find("Shotspawn2");
        bulletSpawn203 = bossGun02.Find("Shotspawn3");
        
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        timer = speed * Time.deltaTime;
        if (Vector3.Distance(bossPosition.position, playerPosition.position) < 18f)
        {
            if(Patterns == BulletPatterns.Nothing && fired == true)
            {
                Patterns = BulletPatterns.Regular;
                fired = false;
            }
            if(Patterns == BulletPatterns.Regular && fired == false)
            {  
                    Instantiate(bullet, bulletSpawn100.position, bulletSpawn100.rotation);
                    Instantiate(bullet, bulletSpawn101.position, bulletSpawn101.rotation);
                    Instantiate(bullet, bulletSpawn102.position, bulletSpawn102.rotation);
                    Instantiate(bullet, bulletSpawn103.position, bulletSpawn103.rotation);
                    Instantiate(bullet, bulletSpawn200.position, bulletSpawn200.rotation);
                    Instantiate(bullet, bulletSpawn201.position, bulletSpawn201.rotation);
                    Instantiate(bullet, bulletSpawn202.position, bulletSpawn202.rotation);
                    Instantiate(bullet, bulletSpawn203.position, bulletSpawn203.rotation);
            }
        }
    }
}