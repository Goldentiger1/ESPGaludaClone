using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupmanager : MonoBehaviour {

    public string pickupAudioEvent;


    void GunAdd() { }
    private void OnTriggerEnter(Collider other) {
        print("jep");
        if (other.name == "Player") {
            GameObject.FindObjectOfType<PlayerShooting>().GunAdd();
            Destroy(gameObject);
            Fabric.EventManager.Instance.PostEvent(pickupAudioEvent);
        }
    }
}
   