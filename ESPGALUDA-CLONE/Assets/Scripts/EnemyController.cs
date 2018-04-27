using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public GameObject enemy;
    Transform oldPosition;
    Transform newPosition;

    public List<GameObject> waypoints = new List<GameObject>();

    void Start() {
       oldPosition = GetComponent<GameObject>().transform;
        newPosition = waypoints[0].transform;
    }

    void Update() {
        
    }

    /* Waypoints listan läpikäynti
     * Pitää tehdä vielä loppuun
     
    void GoThroughListInOrder(List<GameObject> a) {
        foreach(GameObject i in a) {
            if(i == null) {

            }
        }
    }
    */
}
