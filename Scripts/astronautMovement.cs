using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class astronautMovement : MonoBehaviour
{


    Rigidbody2D astroBody;
    Vector3 velocity;
    public Animator animator;

    private float speedAmount = 6f;
    private float jumpAmount = 6f;
    public float groundCheckRadius;

    public bool isGrounded;
    public float delayBeforeDoubleJump;

    public bool Jumping;

    public Transform groundCheck;
    public LayerMask whatisGround;

    public Vector3 respawnPosition;
    public LevelManager theLevelManager;



    // To double jumping
    private bool doubleJumped;


    void Start()
    {
        astroBody = GetComponent<Rigidbody2D>();

        // to Respawn
        respawnPosition = transform.position;
        theLevelManager = FindObjectOfType<LevelManager>();

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatisGround);

         // to move player
         velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
         transform.position += velocity * speedAmount * Time.deltaTime;
         animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        // check if is grounded
        if (isGrounded)
            doubleJumped = false;

        // to jump player
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("isJumping", true);
            Jump();
        }
        
        if(Input.GetButtonDown("Jump") && !isGrounded && !doubleJumped)
        {
            Jump();
            doubleJumped = true;
        }
        // to player rotation
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);

        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }

    }

    public void Jump()
    {
        astroBody.velocity = new Vector2(astroBody.velocity.x, jumpAmount);
    }

    // to catchzone when player falling
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CatchZone")
        {
            theLevelManager.Respawn();
        }

        // to checkpoint but i dont use checkpoints
        if (other.tag == "checkPoint")
        {
              respawnPosition = other.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            animator.SetBool("isJumping", true);

        }
    }





}

