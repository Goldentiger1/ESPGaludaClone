using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    public GameObject ship;

    void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == LayerMask.NameToLayer("Camera")) {
            print("Hello");
            ship.SetActive(true);
        }    
    }

    void Awake() {
        ship.SetActive(false);    
    }
}

