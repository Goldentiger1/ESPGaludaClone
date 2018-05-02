using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    public Transform playfieldCenter;

    public float speed;

    public Vector3 localPos;

    void Start() {
        playfieldCenter = GameObject.Find("CameraObject").transform;
        localPos = transform.position - playfieldCenter.position;
    }

    void Update() {
 
        localPos = localPos + transform.forward * Time.deltaTime * speed;

        transform.position = playfieldCenter.position + localPos;
    }
}
