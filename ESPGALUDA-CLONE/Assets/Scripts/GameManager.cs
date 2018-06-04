using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public enum GameState { Normal, Kakusei, KakuseiOver }

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Text statusText;
    public Text scoreText;
    public Text crystalText;
    public Text goldText;

    public float score;

    public int Gold;

    public Canvas PauseCanvas;

    public GameObject explosion;
    public GameObject blood;
    public GameObject crystal;
    public GameObject gold;
    public GameObject player;

    public GameState gameState;

    public string bgmAudioEvent;

    public PlayerMovement play;


    private const float GOLDEN_RATIO = 1.61803399f; // https://www.youtube.com/watch?v=sj8Sg8qnjOg

    public void CreateCrystals(int number, Transform enemy)
    {
        for (int i = 0; i < number; i++)
        {
            float radius = Mathf.Log(i + 1, 2); // distance from center
            float angle = ((i * GOLDEN_RATIO) % 1) * 2 * Mathf.PI; // direction of offset in radians
            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            Instantiate(crystal, enemy.position + offset, Quaternion.identity);
        }
    }

    public void CreateGold(int number, Transform enemy)
    {
        for (int i = 0; i < number; i++)
        {
            float radius = Mathf.Log(i + 1, 2); // distance from center
            float angle = ((i * GOLDEN_RATIO) % 1) * 2 * Mathf.PI; // direction of offset in radians
            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            Instantiate(gold, enemy.position + offset, Quaternion.identity);
        }
    }

    public void Explosion(int number, Transform enemy)
    {

        for (int o = 0; o < number; o++)
        {
            float radius = Mathf.Log(o + 1, 2); // distance from center
            float angle = ((o * GOLDEN_RATIO) % 1) * Random.Range(0.5f, 2.0f) * Mathf.PI; // direction of offset in radians
            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            var expl = Instantiate(explosion, enemy.position + offset, Quaternion.Euler(90, 0, 0));
            Destroy(expl, 0.5f);
        }
    }

    public void Blood(int number, Transform enemy)
    {
        for (int o = 0; o < number; o++)
        {
            float radius = Mathf.Log(o + 1, 2); // distance from center
            float angle = ((o * GOLDEN_RATIO) % 1) * Random.Range(0.5f, 2.0f) * Mathf.PI; // direction of offset in radians
            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            var expl = Instantiate(blood, enemy.position + offset, Quaternion.Euler(90, 0, 0));
        }

    }

    public void GainGold() {
        Gold += 1;
    }

        public void EnemyKilled(EnemyBehaviour e)
    {
        score += e.score * Mathf.Max(Gold / 10, 1);
        UpdateLivesScoreText();
    }


    public void UpdateLivesScoreText()
    {
        scoreText.text = "Score: " + score;
        statusText.text = "Lives: " + play.Lives;
        crystalText.text = "Crystals: " + (int)play.Crystals;
        goldText.text = "Gold: " + GameManager.instance.Gold;
    }

    public void LifeLost()
    {
        play.Lives--;
        UpdateLivesScoreText();
        if (play.Lives < 0)
        {
            scoreText.text = "You died!";
            statusText.text = "Next time";
            goldText.text = "learn to play,";
            crystalText.text = "You idiot!!";

        }
    }

    public void LifeAdd()
    {
        play.Lives++;
        UpdateLivesScoreText();
    }

    // Use this for initialization
    void Start()
    {
        play = FindObjectOfType<PlayerMovement>();
        UpdateLivesScoreText();
        gameState = GameState.Normal;
        player = GameObject.FindGameObjectWithTag("Player");
        Fabric.EventManager.Instance.PostEvent(bgmAudioEvent);
        PauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
    }

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Kakusei)
        {
            Time.timeScale = 0.5f;
        }
        else Time.timeScale = 1.0f;

        PauseON();
    }

    public void PauseON()
    {
        if (Input.GetKeyDown("space"))
        {
            PauseCanvas.enabled = true;
               
        }

        if (PauseCanvas.enabled == true)
        {
            Time.timeScale = 0;
        }

    }

    public void PauseOFF()
    {
        PauseCanvas.enabled = false;
    }

    public void ReStart()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
