using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    float speed;
    public float targetSpeed;
    public float maxChange;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        speed = Mathf.MoveTowards(speed, targetSpeed, Time.deltaTime * maxChange);
    }
}
