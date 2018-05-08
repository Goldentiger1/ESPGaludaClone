using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour {

    public string BGM1;
    public string sdp_pickup;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Q)) {
            Fabric.EventManager.Instance.PostEvent(BGM1);
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            Fabric.EventManager.Instance.PostEvent(sdp_pickup);
        }
    }
}
