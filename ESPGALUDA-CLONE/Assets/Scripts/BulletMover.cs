using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    public Rigidbody Rb;
    public float Speed;
	

    void Start ()
    {
        Rb = GetComponent<Rigidbody>();
    }
	// Update is called once per frame
	void Update ()
    {
        Rb.velocity = transform.forward * Speed;
    }
}
