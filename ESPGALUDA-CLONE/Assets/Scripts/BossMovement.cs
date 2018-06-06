using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Vector3 localPos;
    public Transform moveTowards;
    public float speed;
    public bool inWaypoint = true;
    public bool movingToWaypoint = true;
    public float startTime;
    public Vector3 target;

    void Start()
    {
        localPos = transform.position - World.center.position;
        moveTowards = GameObject.Find("BossWaypoint").GetComponent<Transform>();
        target = new Vector3(0, 0, 9);
    }

    void Update()
    {
        float move = speed * Time.deltaTime;
        if (movingToWaypoint)
        {
            localPos = Vector3.MoveTowards(localPos, target, move);
            if (Vector3.Distance(localPos, target) < 0.01f)
            {
                movingToWaypoint = false;
                startTime = Time.time;
            }
        } else {
            localPos = target + Vector3.right * Mathf.Sin((Time.time - startTime) * 0.8f) * 3;
        }
        transform.position = World.center.position + localPos;

        /*
         * if (movingToWaypoint) {
         *     move towards waypoint
         *     if (inWaypoint) {
         *         movingToWaypoint = false;
         *     }
         * } else {
         *     liike sivuttain jne
         * }
         */
    }
}