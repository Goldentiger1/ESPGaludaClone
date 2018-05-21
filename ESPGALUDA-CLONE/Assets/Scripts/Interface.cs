using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy {
    void TakeDamage(float dmg);
    
}

interface IPlayer {
    void PlayerHit(float dmg);
}

//abstract public class Enemy {
//    public GameObject crystal;
    
//    void SpawnCoins(int number) {
//        for (int i = 0; i < number; i++) {
//            float radius = Mathf.Log(i + 1, 2); // distance from center
//            float angle = ((i * GOLDENRATIO) % 1) * 2 * Mathf.PI; // direction of offset in radians
//            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
//            Instantiate(Crystal, transform.position + offset, Quaternion.identity);
//        }
//    }
//}