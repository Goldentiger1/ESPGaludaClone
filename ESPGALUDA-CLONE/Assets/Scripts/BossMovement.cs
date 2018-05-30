using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour{

    public Vector3 localpos;
    public Transform moveTowards;
    public float speed;

    void Start()
    {
        moveTowards = GameObject.Find("BossWaypoint").GetComponent<Transform>();
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        localpos = Vector3.MoveTowards(localpos, moveTowards.position, movement);
        if (Vector3.Distance(transform.position, moveTowards.position) < 0.01f)
        {
            speed -= 1;
        }
        transform.position = World.center.position + localpos;
    }

}