using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByArea : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}