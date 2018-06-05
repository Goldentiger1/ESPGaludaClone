using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpeedTrigger : MonoBehaviour {

    public float targetterSpeed;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Camera")) {
            var cam = FindObjectOfType<CameraMovement>();
            cam.targetSpeed = targetterSpeed;

        }
    }
}