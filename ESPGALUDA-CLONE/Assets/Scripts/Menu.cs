﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Canvas MenuCanvas;
    public Canvas CreditsCanvas;
   

   void Start()
   {
        MenuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        CreditsCanvas = GameObject.Find("CreditsCanvas").GetComponent<Canvas>();
       
   }

   public void PlayGame()
   {
        SceneManager.LoadScene("Level01");

   }

    

   public void CreditsMenu()
   {
        CreditsCanvas.enabled = true;
        MenuCanvas.enabled = false;
       
   }

   public void MainMenu()
   {
        MenuCanvas.enabled = true;
        CreditsCanvas.enabled = false;
       
   }    

   public void Quit()
   {

        Application.Quit();


   }
}
