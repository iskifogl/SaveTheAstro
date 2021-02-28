using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{


    private LevelManager theLevelManager;
    private LevelLoader theLevelLoader;
    public int crystalValue;


    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        theLevelLoader = FindObjectOfType<LevelLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theLevelManager.AddCrystal(crystalValue);
            theLevelLoader.AddCrystal(crystalValue);

            Destroy(gameObject);
        }
    }
}
