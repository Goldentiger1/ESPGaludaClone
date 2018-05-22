using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text statusText;
    public Text scoreText;

    static GameObject StaticCrystal;
    public GameObject Crystal;

    private const float GOLDEN_RATIO = 1.61803399f; // https://www.youtube.com/watch?v=sj8Sg8qnjOg

    public static void CreateCrystals(int number, Transform enemy) {
        for (int i = 0; i < number; i++) {
            float radius = Mathf.Log(i + 1, 2); // distance from center
            float angle = ((i * GOLDEN_RATIO) % 1) * 2 * Mathf.PI; // direction of offset in radians
            Vector3 offset = new Vector3(radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            Instantiate(StaticCrystal, enemy.position + offset, Quaternion.identity);
        }
    }

    


	// Use this for initialization
	void Start () {
            StaticCrystal = Crystal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
