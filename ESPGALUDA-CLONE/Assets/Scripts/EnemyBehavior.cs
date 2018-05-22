using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBehaviour : MonoBehaviour {
    public int reward;
    public float hitpoints;

    public void TakeDamage(float dmg) {
        hitpoints -= dmg;
        if (hitpoints < 0) {
            Destroy(gameObject);
            GameManager.CreateCrystals(reward, transform);
        }
    }
}