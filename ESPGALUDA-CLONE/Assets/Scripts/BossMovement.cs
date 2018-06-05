using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform moveTowards;
    public float speed;
    public bool onWaypoint = false;
    public float radius;
    public float angle;
    public float timeNow;

    void Start()
    {
        moveTowards = GameObject.Find("BossWaypoint").GetComponent<Transform>();
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, moveTowards.position, movement);
        if(transform.position == moveTowards.position && onWaypoint == false)
        {
            timeNow = Time.time;
            onWaypoint = true;
            transform.position = Vector3.right * Mathf.Sin(Time.time - timeNow);
        }
    }
}