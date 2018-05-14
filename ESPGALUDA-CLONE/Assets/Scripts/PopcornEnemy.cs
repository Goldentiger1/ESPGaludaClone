using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornEnemy : MonoBehaviour
{
    public GameObject popcornEnemy;
    public float speed;

    public Transform playfieldCenter;
    public Vector3 localPos;

    public PlayerMovement player;

    float timer;
    public float endChase;

    public float minPopcornPositionX = -5f;
    public float minHorizontalAngle;


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

    /* Skripti joka katsoo Popcorn vihollisen viimeisimmän menosuunnan ja tallentaa sen muuttujaan
     * Tietyn ajan kuluttua lopettaa pelaajan jahtaamisen ja asettaa Popcornin menosuunnan suoraan eteenpäin
     * siitä pisteestä, missä se oli viimeiseksi pelaajan jahtaamisen jälkeen.
     */

    void endChaseScript()
    {
        print(timer);

        if (timer >= endChase)
        {
            Quaternion minAngleRotationCCW = Quaternion.AngleAxis(minHorizontalAngle, Vector3.forward);
            Quaternion minAngleRotationCW = Quaternion.AngleAxis(-minHorizontalAngle, Vector3.forward);
            localPos = transform.position - playfieldCenter.position;

            if (Vector3.Angle(localPos, Vector3.forward) < minHorizontalAngle
                && localPos.x >= minPopcornPositionX)
            {
                print("Popcorn is going up and right!");
                localPos = minAngleRotationCCW * Vector3.forward;
            }
            else
            {
                print("Popcorn is going down and right!");
                localPos = minAngleRotationCW * Vector3.forward;
            }

            if(Vector3.Angle(localPos, Vector3.back) > minHorizontalAngle
                && localPos.x <= minPopcornPositionX)
            {
                print("Popcorn is going down and left!");
            }
            else
            {
                print("Popcorn is going up and Left!");
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

