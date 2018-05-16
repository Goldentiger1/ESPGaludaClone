using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeqTrigger : MonoBehaviour {


    public GameObject Ship;
    public float timer;
    public float tickTime;
    public float HowMany;

    void Update() {
        if (HowMany > 0) { 
        timer += Time.deltaTime;
        if (timer > tickTime) {
            Instantiate(Ship);
            timer = 0;
            HowMany--;
            }
        }
    }
}
