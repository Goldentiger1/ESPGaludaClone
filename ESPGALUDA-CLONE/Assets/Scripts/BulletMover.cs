using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    public float speed;

    public Vector3 localPos;
    

    void Start() {
        //playfieldCenter = GameObject.Find("CameraObject").transform;
        localPos = transform.position - World.center.position;
        Destroy(gameObject, 0.6f);
    }

    void Update() {

        localPos = localPos + transform.forward * Time.deltaTime * speed;

        transform.position = World.center.position + localPos;
    }
}
