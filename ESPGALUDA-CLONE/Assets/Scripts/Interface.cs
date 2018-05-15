using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Enemy {
    void TakeDamage(float dmg);
}

interface Player {
    void PlayerHit(float dmg);
}