using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBehaviour : MonoBehaviour {
    public int reward;
    public int expl;

    public float hitpoints;
    public float score;
    public float fireRate;
    public float kakuseiFireRate;

    public string destroyAudioEvent;

    public void TakeDamage(float dmg) {
        hitpoints -= dmg;
        if (hitpoints < 0) {
            Destroy(gameObject);
            GameManager.instance.Explosion(expl, transform);
            GameManager.instance.EnemyKilled(this);
            GameManager.instance.CreateCrystals(reward, transform);
            Fabric.EventManager.Instance.PostEvent(destroyAudioEvent);
            
        }
    }
}