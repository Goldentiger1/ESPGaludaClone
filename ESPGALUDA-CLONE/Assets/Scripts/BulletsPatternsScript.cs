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

public class BulletsPatternsScript : MonoBehaviour {

    public enemyTypes current;
    public float bulletsSpeed;
    public int enemyBulletsAmount;
    public float bulletsMovementXAxis;
    public float bulletsMovementZAxis;
    public GameObject enemyBulletsPrefab;
    public GameObject bulletsSpawnpoint;
    public bool bulletsPatternTriangle;

    


    void Start()
    {
        bulletsPatternTriangle = false;
    }

    void Update()
    {
        if(current == enemyTypes.Cannon){
            bulletsPatternTriangle = true;

        }
    }
}
