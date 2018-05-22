using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy {
    void TakeDamage(float dmg);
    
}

interface IPlayer {
    void PlayerHit(float dmg);
}



