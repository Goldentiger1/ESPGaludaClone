using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        var pos = Vector3.zero; // Nollataan Sijainti.
        pos.x = player.transform.position.x; // Seurataan pelaajaa (X) Akselilla. 
       // pos.z = player.transform.position.z; // Seurataan pelaajaa (Z) Akselilla. 
        transform.localPosition = pos;
    }
}
