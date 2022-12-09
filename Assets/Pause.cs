using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame() ;
            }
            else
            {
                PauseGame();
            } 
        }
    }
    public void ResumeGame()
    {
       pauseMenu.SetActive(false);
       Time.timeScale =1f;
       isGamePaused = false;
    }

    void PauseGame()
    {
       pauseMenu.SetActive(true);
       Time.timeScale =0f;
       isGamePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit");

    }
}
