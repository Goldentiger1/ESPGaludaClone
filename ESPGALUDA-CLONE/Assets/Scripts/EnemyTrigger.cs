using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

    public List<GameObject> ships;

    void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == LayerMask.NameToLayer("Camera")) {
            foreach (var ship in ships)
            ship.SetActive(true);
        }    
    }

    void Awake() {
        foreach (var ship in ships)
            ship.SetActive(false);
    }
}

