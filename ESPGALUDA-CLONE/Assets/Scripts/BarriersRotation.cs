using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarriersRotation : MonoBehaviour {
    

    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.right, 4  * Time.unscaledDeltaTime);

    }
}
