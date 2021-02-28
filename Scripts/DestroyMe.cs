using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyMe : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public string sceneNameToLoad;
    public float waitToRespawn;
    public GameObject thePlayer;
    public Animator animator;

    // Start is called before the first frame update


    void Start()
    {

    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("isDead", true);
            thePlayer.gameObject.SetActive(false);
            StartCoroutine("LoadLevel");
        }
    }





    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(waitToRespawn);
        SceneManager.LoadScene(sceneNameToLoad);
    }

}
