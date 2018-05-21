using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class World : MonoBehaviour {
    public static Transform center;



    private void Awake() {
        center = transform;
    }

}
