using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupmanager : MonoBehaviour {

    public string pickupAudioEvent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        Fabric.EventManager.Instance.PostEvent(pickupAudioEvent);
    }
}
