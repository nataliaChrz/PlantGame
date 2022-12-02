using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  public void Quitbutton() { 
    Application.Quit();
    Debug.Log("Game closed");
  }

  public void StartGame() {
    SceneManager.LoadScene("PlantScene")
  }
}
