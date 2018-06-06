using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : EnemyBehaviour
{
    public int currentHealth;
    public Slider bossHealthSlider;
    public CameraMovement cameraMove;

    void Start()
    {
        bossHealthSlider = GameObject.Find("BossHealthSlider").GetComponent<Slider>();
        bossHealthSlider.maxValue = 100f;
        cameraMove = GameObject.Find("CameraObject").GetComponent<CameraMovement>();
    }

    void Update()
    {
        currentHealth = (int)hitpoints;
        bossHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            cameraMove.enabled = true;
        }
        
    }

}
