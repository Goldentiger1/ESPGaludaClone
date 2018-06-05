using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Vector3 localPos;
    public Transform moveTowards;
    public float speed;
    public bool onWaypoint = false;
    public float startTime;

    void Start()
    {
        moveTowards = GameObject.Find("BossWaypoint").GetComponent<Transform>();
    }

    void Update()
    {
        float move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTowards.position, move);
        if(Vector3.Distance(transform.position, moveTowards.position) < 0.01f && onWaypoint == false)
        {
            onWaypoint = true;
            startTime = Time.time;
            localPos = World.center.position - transform.position;
                
                // Vector3.right * Mathf.Sin(Time.time - startTime);
        }
    }
}