using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMover : MonoBehaviour
{

    public float speed;
    public float dmg;

    public Vector3 localPos;

    void Start()
    {
        //playfieldCenter = GameObject.Find("CameraObject").transform;
        localPos = transform.position - World.center.position;
        Destroy(gameObject, 2.0f);
    }

    void Update()
    {

        localPos = localPos + transform.forward * Time.deltaTime * speed;
        transform.position = World.center.position + localPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            player.PlayerHit(dmg);
            print("OUCH");
            //Destroy(gameObject);
        }
    }
}
