using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointController : MonoBehaviour
{


    public Sprite flageClosed;
    public Sprite flageOpen;
    private SpriteRenderer theSpriteRenderer;
    public bool checkPointActive;

    void Start()
    {
        theSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            theSpriteRenderer.sprite = flageClosed;

            checkPointActive = true;
        }



    }


}
