using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletDamage : MonoBehaviour {

    public float dmg;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        var player = other.GetComponent<IPlayer>();
        if (player != null) {
            player.PlayerHit(dmg);
            print("Player hit");
            Destroy(gameObject);

        }
    }

}
