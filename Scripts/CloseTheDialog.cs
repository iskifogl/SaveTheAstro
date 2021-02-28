using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseTheDialog : MonoBehaviour
{
    public GameObject dialogPanel;
    public Dialog dialog;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(false);
            dialog.textDisplay.text = "";
        }


    }

}
