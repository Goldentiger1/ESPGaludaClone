using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour{

    public Vector3 localpos;
    public Vector3 moveTowards;

    void Update()
    {
        transform.position = World.center.position + localpos;
    }

}