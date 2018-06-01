using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyTypes{

    Nothing,
    Cannon,
    Popcorn,
    Soldier,
    Gunship,
    Boss
}

public class BulletsPatternsScript : MonoBehaviour{

    public enemyTypes Class;
   // public float bulletsXDirection;
   // public float bulletsZDirection;
   // public Vector3 bulletsMovementDirection;
    public Transform bulletsSpawnpoint0;
    public Transform bulletsSpawnpoint1;
    public Transform bulletsSpawnpoint2;
    public Transform bulletsSpawnpoint3;
    // public float bulletsAngle;
    // public float bulletsSpeed;
    public GameObject enemyBulletPrefab;

    void Update()
    {
        /*
        float movement = Time.deltaTime * bulletsSpeed;
        bulletsXDirection = bulletsSpawnpoint.position.x + Mathf.Sin(bulletsAngle) * movement;
        bulletsZDirection = bulletsSpawnpoint.position.z + Mathf.Cos(bulletsAngle) * movement;
        bulletsMovementDirection = new Vector3(bulletsXDirection, 0f, bulletsZDirection);
        */

        if (Class == enemyTypes.Cannon)
        {
            GameObject clone0 = Instantiate(enemyBulletPrefab, bulletsSpawnpoint0.position, transform.rotation);
            GameObject clone1 = Instantiate(enemyBulletPrefab, bulletsSpawnpoint1.position, transform.rotation);
            GameObject clone2 = Instantiate(enemyBulletPrefab, bulletsSpawnpoint2.position, transform.rotation * Quaternion.LookRotation(new Vector3(-1, 0, 2)));
            GameObject clone3 = Instantiate(enemyBulletPrefab, bulletsSpawnpoint3.position, transform.rotation * Quaternion.LookRotation(new Vector3(1, 0, 2)));
        }
    }
}
