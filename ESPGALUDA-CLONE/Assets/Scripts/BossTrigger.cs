using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {
    public BossSpawner bM;
    public CameraMovement cM;
    public GameObject bH;

    void Start()
    {
        bM = GameObject.Find("BossSpawner").GetComponent<BossSpawner>();
        cM = GameObject.Find("CameraObject").GetComponent<CameraMovement>();
        bH = GameObject.Find("BossHealthUI");
        //bH.SetActive(false);
        bM.enabled = false;

    }

    void OnTriggerEnter(Collider box)
    {
       if(box.gameObject.layer == LayerMask.NameToLayer("Camera"))
        {
            bH.SetActive(true);
            bM.enabled = true;
            cM.enabled = false;
        } 
    }

}
