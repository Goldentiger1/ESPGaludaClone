using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour {

    public string crystalAudioEvent;
    public Vector3 localPos;
    private Vector3 currentDirection = Vector3.forward;
    public float speed;

    public PlayerMovement player;

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Player") {
            Destroy(gameObject);
            Fabric.EventManager.Instance.PostEvent(crystalAudioEvent);
            GameObject.FindObjectOfType<PlayerMovement>().GainCrystal();
            GameManager.instance.UpdateLivesScoreText();

        }
    }

    void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        localPos = transform.position - World.center.position;
    }

    void Update() {
        float movement = speed * Time.deltaTime;
        localPos = Vector3.MoveTowards(localPos, player.localPos, movement);
        currentDirection = (player.localPos - localPos).normalized;
        transform.position = World.center.position + localPos;
    }
}