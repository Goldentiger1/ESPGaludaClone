using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : EnemyBehaviour
{
    public int startingHealth = 1000;
    public int currentHealth;
    public Slider bossHealthSlider;

    void Start()
    {
        bossHealthSlider = GameObject.Find("BossHealthSlider").GetComponent<Slider>();
        currentHealth = startingHealth;
    }

}
