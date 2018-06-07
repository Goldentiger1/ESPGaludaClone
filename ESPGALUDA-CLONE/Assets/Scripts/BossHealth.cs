using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : EnemyBehaviour
{
    public int currentHealth;
    public Slider bossHealthSlider;
    public CameraMovement cameraMove;
    public string stopAudioEvent;
    public string bgmAudioEvent;

    void Start()
    {
        bossHealthSlider = GameObject.Find("BossHealthSlider").GetComponent<Slider>();
        bossHealthSlider.maxValue = 200f;
        cameraMove = GameObject.Find("CameraObject").GetComponent<CameraMovement>();
    }

    void Update()
    {
        currentHealth = (int)hitpoints;
        bossHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            Fabric.EventManager.Instance.PostEvent(stopAudioEvent);
            Fabric.EventManager.Instance.PostEvent(bgmAudioEvent);
            cameraMove.enabled = true;
        }
        
    }

}
