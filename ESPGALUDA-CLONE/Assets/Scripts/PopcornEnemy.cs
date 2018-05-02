using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopcornEnemy : MonoBehaviour {

    public GameObject popcornEnemy;
    public GameObject playerCoordinates;
    public float speed;

    float timer;
    public float endChase;

    Transform oldPosition;
    Transform newPosition;

    void Start()
    {
        oldPosition = GetComponent<Transform>();
        newPosition = playerCoordinates.GetComponent<Transform>();
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(oldPosition.position, newPosition.position, movement);
        timer += Time.deltaTime;
    }

    /* Skripti joka katsoo Popcorn vihollisen viimeisimmän menosuunnan ja tallentaa sen muuttujaan
     * Tietyn ajan kuluttua lopettaa pelaajan jahtaamisen ja asettaa Popcornin menosuunnan suoraan eteenpäin
     * siitä pisteestä, missä se oli viimeiseksi pelaajan jahtaamisen jälkeen.
     */
    void endChaseScript() {

        if(timer >= endChase) {          

        }
    }

}
