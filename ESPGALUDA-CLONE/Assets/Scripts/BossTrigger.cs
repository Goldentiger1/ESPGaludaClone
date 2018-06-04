using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {
    public BossSpawner bM;

    void Start()
    {
        bM = GameObject.Find("BossSpawner").GetComponent<BossSpawner>();
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
