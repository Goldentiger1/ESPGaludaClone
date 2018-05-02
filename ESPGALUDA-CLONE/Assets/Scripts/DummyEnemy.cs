using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour {
    // TODO: optimize - set this on instantiate, don't search in Awake
    public Transform playfieldCenter;

    public Vector3 localPos;

	void Awake() {
        playfieldCenter = GameObject.Find("CameraObject").transform;
	}
	
	void Update () {
        // stays in place on screen if localPos is not changed

        // testing: circle movement
        localPos = new Vector3(Mathf.Cos(Time.time), 0f, Mathf.Sin(Time.time)) * 3f;

        transform.position = playfieldCenter.position + localPos;
	}
}
