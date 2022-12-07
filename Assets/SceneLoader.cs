using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using_UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public void PlantScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
  )
}
