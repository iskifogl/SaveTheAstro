using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    //public string sceneNameToLoad;

    public void ButtonLoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = Mathf.Approximately(Time.timeScale, 1.0f) ? 1.0f : 1.0f;

    }
}
