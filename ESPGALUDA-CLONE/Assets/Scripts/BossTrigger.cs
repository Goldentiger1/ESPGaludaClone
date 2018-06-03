using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {
    public BossMovement bM;

    void Start()
    {
        bM = GameObject.Find("Boss").GetComponent<BossMovement>();
        bM.enabled = false;
    }

    void OnTriggerEnter(Collider box)
    {
       if(box.tag == "Player")
        {
            bM.enabled = true;
        } 
    }

}
