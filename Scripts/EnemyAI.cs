using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public GameObject thePlayer;
    private Transform playerPos;
    private Vector3 currentPos;
    public float distance;
    public float speedEnemy;
    //  public string sceneNameToLoad;
    //  public float waitToRespawn;
    public GameObject enemy;

    private void Start()
    {
        playerPos = thePlayer.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
    }

    private void Update()
    {

        if (enemy.transform.position.x > thePlayer.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }

        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerPos.position) < distance)
        {

            transform.position = Vector3.MoveTowards(transform.position , playerPos.position,
            speedEnemy * Time.deltaTime);
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPos,
                speedEnemy * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CatchZone")
        {
            Destroy(GetComponent<Rigidbody>());
        }
    }
}