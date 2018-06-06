using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation1 : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Time.deltaTime, 0, Space.World);
    }
}
