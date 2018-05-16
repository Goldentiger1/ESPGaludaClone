using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour {

    public Vector3 localPos;
	
	void Update () {
        // stays in place on screen if localPos is not changed

        // testing: circle movement
        localPos = new Vector3(Mathf.Cos(Time.time), 0f, Mathf.Sin(Time.time)) * 3f;

        transform.position = World.center.position + localPos;
	}
}
