using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public GameManager gm;
    public AudioSource audioSource;



    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gm.PauseGame();
        audioSource.Pause();
       
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gm.ResumeGame();
        audioSource.UnPause();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

   
}
