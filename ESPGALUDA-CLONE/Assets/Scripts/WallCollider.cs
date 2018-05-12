using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour {

    public Transform playfieldCenter;
    public Vector3 localPos;
    public PlayerMovement player;

    // Use this for initialization
    void Start ()
    {
        playfieldCenter = GameObject.Find("CameraObject").transform;
        localPos = transform.position - playfieldCenter.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0,0,Time.deltaTime);               

        transform.position = playfieldCenter.position + localPos;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            print(gameObject.name + "Collision with " + " "  + col.gameObject.name);
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            //player.transform.Translate(Vector3.zero);
            //transform.position = Vector3.zero;
            player.transform.position = Vector3.zero;


            print("Object is outside the Game area " + " " + col.gameObject.name);
        }

    } 
    
}
