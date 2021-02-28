using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject dialogPanel;
    public astronautMovement astroMove;
    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public Button Button1;




    void Start()
    {
        Button1.onClick.AddListener(Button1Clicked);

        astroMove = FindObjectOfType<astronautMovement>();
        dialogPanel.SetActive(false);
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);
            StartCoroutine(Type());
        }


     }

    void Button1Clicked()
    {
        //This method will be called when button1 is clicked 
        //Do whatever button 1 does
        Button1.gameObject.SetActive(false);
        StartCoroutine(ButtonDelay());
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator ButtonDelay()
    {
            yield return new WaitForSeconds(1.30f);
            Button1.gameObject.SetActive(true);
    }



    public void NextSentence()
    {

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            dialogPanel.SetActive(false);

        }

    }

}
