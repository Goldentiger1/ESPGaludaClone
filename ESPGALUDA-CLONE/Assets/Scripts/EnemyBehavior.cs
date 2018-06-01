using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBehaviour : MonoBehaviour {
    public int crystalReward;
    public int goldReward;
    public int expl;
    public int blood;

    public float hitpoints;
    public float score;
    public float fireRate;
    public float kakuseiFireRate;
    public float powerupProbability;

    public GameObject spawnedAtDeath;

    GameManager g;
    
    public string destroyAudioEvent;

    public void SetSpawnAtDeath(GameObject g) {
        spawnedAtDeath = g;
    }

    public void inKakusei() {
        fireRate = kakuseiFireRate;
    }

    public void TakeDamage(float dmg) {
        g = GameManager.instance;

        hitpoints -= dmg;
        if (hitpoints < 0) {
            Destroy(gameObject);
            g.Explosion(expl, transform);
            g.Blood(blood, transform);
            g.EnemyKilled(this);
            if (g.gameState == GameState.Normal) {
                g.CreateCrystals(crystalReward, transform);
            }
            if (g.gameState == GameState.Kakusei) {
                g.CreateGold(goldReward, transform);
            }
            Fabric.EventManager.Instance.PostEvent(destroyAudioEvent);
            bool isPowerup = Random.value < powerupProbability;
            if (isPowerup) {
                if (spawnedAtDeath != null) {
                    var g = Instantiate(spawnedAtDeath);
                    g.transform.position = transform.position;
                }
            }
        }
    }
}