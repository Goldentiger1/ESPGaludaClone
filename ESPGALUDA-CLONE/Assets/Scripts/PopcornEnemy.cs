using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornEnemy : MonoBehaviour, Enemy
{
    public GameObject popcornEnemy;
    public float speed;

    public Transform playfieldCenter;
    public Vector3 localPos;

    public PlayerMovement player;

    float timer;
    public float endChase;

    public float minPopcornPositionX;
    public float minHorizontalAngle;


    public void TakeDamage(float dmg) {


    }

    void Start()
    {
        localPos = transform.position - playfieldCenter.position;
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        localPos = Vector3.MoveTowards(localPos, player.localPos, movement);
        transform.position = playfieldCenter.position + localPos;
        timer += Time.deltaTime;
        endChaseScript();
    }

    /* endChaseScript katsoo tietyn ajan kuluttua PopcornEnemyn viimeisimmän menosuunnan
     * ja asettaa PopcornEnemylle uuden kulkusuunnan playerin jahtaamisen sijasta viimeisimpään
     * menosuuntaan päin.
     * 
     */
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
        }
    }
}

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

/* 
 * ESIMERKKI, joka pitäisi muokata tähän koodiin sopivaksi.
 * 
 *  if (Vector3.Angle(rb.velocity, Vector3.right) < minHorizontalAngle) {
        if (lastVelocity.y >= 0) {
            print("Bounced  right, was going up!");
            rb.velocity = minAngleRotationCCW * Vector3.right;
        }
        else {
            print("Bounced right, was going down!");
            rb.velocity = minAngleRotationCW * Vector3.right;
        }
    }
    // TODO: Fix horizontal left!
    if(Vector3.Angle(rb.velocity, Vector3.right) < minHorizontalAngle) {
        if(lastVelocity.y >= 0) {
            print("Bounced left, was going up!");
            rb.velocity = minAngleRotationCW * Vector3.left;
            //rb.velocity = minAngleRotationCCW * Vector3.left;
        }
        else {
            print("Bounced left, was going down!");
            //rb.velocity = minAngleRotationCW * Vector3.left;
            rb.velocity = minAngleRotationCCW * Vector3.left;
        }
        */

