using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour {

    public Image redInd;
    private float fullInd;
    public PlayerMovement player;


    void Start() {
        redInd = GameObject.Find("RedInd").GetComponent<Image>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update() {
        KakuseiModeIndicator();

    }

    void KakuseiModeIndicator()
    {

        if (GameManager.instance.kakusei)
        {
            //player = Gameobject.FindGameObjectWithTag("Player");
            //redInd = GetComponentInChildren<Image>();

            fullInd++;
            fullInd = player.Crystals / 500f; //player.Crystals / 500f;
                                 
            redInd.fillAmount = fullInd; 
        } 
    }
}