using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Countdown : MonoBehaviour
{

    public float timeStart;
    public Text textBox;
    public string sceneNameToLoad;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();

        if (timeStart  <= 0)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }

    }
}
