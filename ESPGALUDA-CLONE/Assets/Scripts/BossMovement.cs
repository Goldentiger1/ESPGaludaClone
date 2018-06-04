using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Vector3 localpos;
    public Transform moveTowards;
    public float speed;
    public Vector3 bossWaypoint;

    void Start()
    {
        localpos = transform.position - World.center.position;
        moveTowards = GameObject.Find("BossWaypoint").GetComponent<Transform>();
    }

    void Update()
    {
        bossWaypoint = moveTowards.position - World.center.position;
        float movement = speed * Time.deltaTime;
        localpos = Vector3.MoveTowards(localpos, bossWaypoint, movement);
        transform.position = World.center.position + localpos;
    }

}