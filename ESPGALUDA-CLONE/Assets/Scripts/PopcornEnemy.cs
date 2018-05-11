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

    Vector3 oldPos;
    Vector3 newPos;

    float timer;
    public float endChase;

    void Start()
    {
        localPos = transform.position - playfieldCenter.position;
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        localPos = Vector3.MoveTowards(localPos, player.localPos, movement);

        transform.position = playfieldCenter.position + localPos;
    }

    /* Skripti joka katsoo Popcorn vihollisen viimeisimmän menosuunnan ja tallentaa sen muuttujaan
     * Tietyn ajan kuluttua lopettaa pelaajan jahtaamisen ja asettaa Popcornin menosuunnan suoraan eteenpäin
     * siitä pisteestä, missä se oli viimeiseksi pelaajan jahtaamisen jälkeen.
     */

    void endChaseScript()
    {
        if (timer >= endChase)
        {

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

