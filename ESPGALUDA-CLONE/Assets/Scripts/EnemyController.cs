using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public GameObject enemy;
    public Transform oldPosition;  

    public List<GameObject> waypoints = new List<GameObject>();

    void Start() {
        
    }
}
