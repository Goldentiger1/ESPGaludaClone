using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    public float dmg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        var enemy = other.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(dmg);
        }
    }
}
