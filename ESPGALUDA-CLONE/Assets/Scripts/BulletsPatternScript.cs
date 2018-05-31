using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPatternScript : MonoBehaviour{

    public void TowerBulletsPatterns(GameObject shotspawn, GameObject enemyBullet)
    {
        GameObject clone = Instantiate(enemyBullet);
        clone.transform.position = shotspawn.transform.position;
        clone.transform.rotation = shotspawn.transform.rotation;
    }

}