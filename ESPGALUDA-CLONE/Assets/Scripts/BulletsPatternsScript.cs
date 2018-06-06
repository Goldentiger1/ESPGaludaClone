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
    public Transform bulletSpawn01;
    public Transform bulletSpawn02;

    public GameObject bullet;

    void Start()
    {
        bossPosition = GetComponent<Transform>();
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        bossGun01 = GameObject.Find("BossGun1").transform;
        bossGun02 = GameObject.Find("BossGun2").transform;
        bulletSpawn01 = bossGun01.Find("Shotspawn");
        bulletSpawn02 = bossGun02.Find("Shotspawn");
    }

    void Update()
    {
        if (Vector3.Distance(bossPosition.position, playerPosition.position) < 8f)
        {
            if(Patterns == BulletPatterns.Nothing && fired == true)
            {
                Patterns = BulletPatterns.Regular;
                fired = false;
            }
            if(Patterns == BulletPatterns.Regular && fired == false)
            {
                Instantiate(bullet, bulletSpawn01.position, bulletSpawn01.rotation);
                Instantiate(bullet, bulletSpawn02.position, bulletSpawn02.rotation);
                //bossGun01 = Vector3.RotateTowards()
            }
        }
    }
}