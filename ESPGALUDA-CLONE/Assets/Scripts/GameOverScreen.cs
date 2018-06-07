﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("Level01");
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }

        if (Input.GetButtonDown("X360_A"))
        {
            SceneManager.LoadScene("Level01");
        }
        if (Input.GetButtonDown("X360_B"))
        {
            Application.Quit();
        }
    }
}
