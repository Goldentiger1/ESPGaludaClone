using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Text statusText;
    public Text scoreText;
    public Text crystalText;

    public float score;

    public GameObject explosion;
    public GameObject blood;
    public GameObject crystal;
    public GameObject player;

    public bool kakusei;

    public string bgmAudioEvent;
    private string p;

    public PlayerMovement play;

    private const float GOLDEN_RATIO = 1.61803399f; // https://www.youtube.com/watch?v=sj8Sg8qnjOg

    public void CreateCrystals(int number, Transform enemy) {
        for (int i = 0; i < number; i++) {
            float radius = Mathf.Log(i + 1, 2); // distance from center
            float angle = ((i * GOLDEN_RATIO) % 1) * 2 * Mathf.PI; // direction of offset in radians
            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            Instantiate(crystal, enemy.position + offset, Quaternion.identity);
        }
    }

    public void Explosion(int number, Transform enemy) {

        for (int o = 0; o < number; o++) {
            float radius = Mathf.Log(o + 1, 2); // distance from center
            float angle = ((o * GOLDEN_RATIO) % 1) * Random.Range(0.5f, 2.0f) * Mathf.PI; // direction of offset in radians
            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            var expl = Instantiate(explosion, enemy.position + offset, Quaternion.Euler(90,0,0));
            Destroy(expl, 0.5f);
        }
    }

    public void Blood (int number, Transform enemy) {
        for (int o = 0; o < number; o++) {
            float radius = Mathf.Log(o + 1, 2); // distance from center
            float angle = ((o * GOLDEN_RATIO) % 1) * Random.Range(0.5f, 2.0f) * Mathf.PI; // direction of offset in radians
            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            var expl = Instantiate(blood, enemy.position + offset, Quaternion.Euler(90, 0, 0));
        }

    }

    public void EnemyKilled(EnemyBehaviour e) {
        score += e.score;
        UpdateLivesScoreText();
    }


    public void UpdateLivesScoreText() {
        scoreText.text = "Score: " + score;
        statusText.text = "Lives: " + play.Lives;
        crystalText.text = "Crystals: " + (int)play.Crystals;

    }

    public void LifeLost() {
        play.Lives--;
        UpdateLivesScoreText();
        if (play.Lives < 0) {
            scoreText.text = "You died!";
            statusText.text = "Next time";
            crystalText.text = "learn to play!";
        }
    }

    public void LifeAdd() {
        play.Lives++;
        UpdateLivesScoreText();
    }

	// Use this for initialization
	void Start () {
        play = FindObjectOfType<PlayerMovement>();
        UpdateLivesScoreText();
        kakusei = false;
        statusText.text = "Lives: " + play.Lives;
        scoreText.text = "Score: " + score;
        player = GameObject.FindGameObjectWithTag("Player");
        Fabric.EventManager.Instance.PostEvent(bgmAudioEvent);
	}

    void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update () {

    }
}
