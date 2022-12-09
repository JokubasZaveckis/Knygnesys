using System.Net.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overlays : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public static bool isGameOver=false;

    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject deathMenuUI;
    public GameObject inGameScores;

    //ads start
    public AdsManager ads;
    //ads end
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
         if(isGameOver)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        deathMenuUI.SetActive(true); 
        inGameScores.SetActive(false);

        //ads start
        ads.PlayAd();
        //ads end
    }
    public void Resume()
    {
        isGameOver = false;
        deathMenuUI.SetActive(false); 
        pauseMenuUI.SetActive(false);
        inGameScores.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseButton.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseButton.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    public void Restart()
    {
        
        
        Resume();
        SceneManager.LoadScene("SampleScene");
    }

    
}
