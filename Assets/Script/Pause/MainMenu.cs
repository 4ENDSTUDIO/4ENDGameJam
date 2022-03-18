using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
  
    public void START()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }
    public void QuitGame()
    {
        Debug.Log("Quiting Game....");
        Application.Quit();
    }
}
