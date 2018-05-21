using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    public GameObject Wave;

    void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == LayerMask.NameToLayer("Camera")) {
            Wave.SetActive(true);
        }    
    }

    void Awake() {

            Wave.SetActive(false);
    }
}

