using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Renderer plane;
    public float camWidth;

    // Update is called once per frame
    void Start() {
        player = GameObject.Find("Player").transform;
        plane  = GameObject.Find("Plane").GetComponent<Renderer>();
        var c = GameObject.FindObjectOfType<AspectRatioScript>();
        //camWidth = c.GetComponent<Camera>().orthographicSize * c.fixedAspectRatio;
    }


	void LateUpdate () {
        var newpos = transform.localPosition;

        //newpos.x = Mathf.Clamp(player.position.x, plane.bounds.min.x + camWidth * 0.5f, plane.bounds.max.x - camWidth * 0.5f);
        float playerMax = plane.bounds.max.x;
        float camMax = playerMax - (camWidth * 0.5f);

        newpos.x = (player.position.x / playerMax) * camMax;

        transform.localPosition = newpos;
	}
}
