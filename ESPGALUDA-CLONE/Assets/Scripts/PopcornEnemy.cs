﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornEnemy : EnemyBehaviour
{
    public GameObject popcornEnemy;
    public float speed;

    //public float hitpoints;

    public Vector3 localPos;

    public PlayerMovement player;
    public GameObject Crystal;

    float timer;
    public float endChase;

    private Vector3 currentDirection = Vector3.forward;

    //public float minPopcornPositionX;
    //public float minHorizontalAngle;


    //public void TakeDamage(float dmg) {
    //    hitpoints -= dmg;
    //    if (hitpoints < 0) {
    //        Destroy(gameObject);
    //        GameManager.CreateCrystals(1, transform);
    //    }
    //}

    void Start()
    {
        localPos = transform.position - World.center.position;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        if (timer <= endChase)
        {
            // Popcorn rotation
            Vector3 targetDirection = player.transform.position - transform.position;
            targetDirection.y = 0;
            if (targetDirection != Vector3.zero)
            {
                Quaternion currentRotation = transform.rotation;
                //Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDirection);
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * 180);
            }
            // Popcorn movement
            localPos = Vector3.MoveTowards(localPos, player.localPos, movement);
            currentDirection = (player.localPos - localPos).normalized;
        } else {
            localPos += currentDirection * movement;

        }
        transform.position = World.center.position + localPos;
        timer += Time.deltaTime;
    }

}

    /* endChaseScript katsoo tietyn ajan kuluttua PopcornEnemyn viimeisimmän menosuunnan
     * ja asettaa PopcornEnemylle uuden kulkusuunnan playerin jahtaamisen sijasta viimeisimpään
     * menosuuntaan päin.
     * 
     */

        /*
    void endChaseScript()
    {
        print(timer);

        if (timer >= endChase)
        {
            localPos = transform.position - playfieldCenter.position;

            if (Vector3.Angle(localPos, Vector3.forward) > minHorizontalAngle)
            {
                if (localPos.x > minPopcornPositionX)
                {
                    print("PopcornEnemy is going up and right!");
                }
                else
                {
                    print("PopcornEnemy is going down and right!");
                }
            }
            */

/*
public GameObject popcornEnemy;
public Vector3 localPos;
public float speed;

Transform oldPosition;
Transform newPosition;

public Transform playfieldCenter;   
public GameObject playerCoordinates;

float timer;
public float endChase;

void Start()
{

    oldPosition = GetComponent<Transform>();
    newPosition = playerCoordinates.GetComponent<Transform>();
    localPos = transform.position - playfieldCenter.position;
}

void Update()
{
    float movement = speed * Time.deltaTime;
    localPos = localPos + Vector3.MoveTowards(oldPosition.position, newPosition.position, movement);      
   // transform.position = Vector3.MoveTowards(oldPosition.position, newPosition.position, movement);
    timer += Time.deltaTime;
}

*/