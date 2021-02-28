using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;
    public astronautMovement thePlayer;

    // Spinning Crystal
    public int crystalCount;
    public Text crystalText;


    void Start()
    {
        //For the find player
        thePlayer = FindObjectOfType<astronautMovement>();
        crystalText.text = "Find";

    }

    void Update()
    {

    }


    public void Respawn()
    {
            StartCoroutine("RespawnCo");

    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddCrystal (int crystalToAdd)
    {
        crystalCount += crystalToAdd;
        crystalText.text = "Success";
    }

}
