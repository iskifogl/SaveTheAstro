using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
   // public string StartMenu;



    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;

    }


    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 1.0f) ? 1.0f : 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }



}
