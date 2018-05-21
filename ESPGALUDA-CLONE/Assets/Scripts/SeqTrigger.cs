using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeqTrigger : MonoBehaviour {


    public GameObject Ship;
    public float timer;
    public float tickTime;
    public float HowMany;
    PlayerMovement player;

    void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update() {
        if (HowMany > 0) { 
        timer += Time.deltaTime;
        if (timer > tickTime) {
                var enemy = Instantiate(Ship, transform.position, Quaternion.identity);
                enemy.transform.position = transform.position;
                var popc = enemy.GetComponent<PopcornEnemy>();
                if (popc != null) {
                    popc.player = player;
                }
            timer = 0;
            HowMany--;
            }
        }
    }
}
