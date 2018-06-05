using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : EnemyBehaviour
{
    public int currentHealth;
    public Slider bossHealthSlider;

    void Start()
    {
        bossHealthSlider = GameObject.Find("BossHealthSlider").GetComponent<Slider>();
    }

    void Update()
    {
        currentHealth = (int)hitpoints;
        bossHealthSlider.value = currentHealth;
    }

}
