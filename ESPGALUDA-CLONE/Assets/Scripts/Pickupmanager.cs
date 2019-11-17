using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupmanager : MonoBehaviour {

    public string pickupAudioEvent;


    void LifeAdd() { }
    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            GameObject.FindObjectOfType<GameManager>().LifeAdd();
            Destroy(gameObject);
            //Fabric.EventManager.Instance.PostEvent(pickupAudioEvent);
        }
    }
}
   