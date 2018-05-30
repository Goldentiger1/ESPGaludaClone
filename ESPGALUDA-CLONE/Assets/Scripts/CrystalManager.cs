using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour {

    public Image redInd;
    public Image WhiteInd;
    private float fullInd;
    public PlayerMovement player;


    void Start() {
        redInd = GameObject.Find("RedInd").GetComponent<Image>();
        WhiteInd = GameObject.Find("WhiteInd").GetComponent<Image>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update() {
        KakuseiModeIndicator();

    }

    void KakuseiModeIndicator()
    {
            redInd.enabled = false;
            WhiteInd.enabled = false;
            fullInd++;
            fullInd = player.Crystals / 500f; //player.Crystals / 500f;
                                 
            redInd.fillAmount = fullInd; 

        if (GameManager.instance.kakusei)
        {
            redInd.enabled = true;
            WhiteInd.enabled = true;
            fullInd -= player.Crystals-- * (Time.deltaTime / 4);
        }
        
    }
}