using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MobileController : MonoBehaviour
{

    private float speedAmount = 5f;
    private float jumpAmount = 6f;

    public float groundCheckRadius;
    public float delayBeforeDoubleJump;

    public bool isGrounded, Jumping;
    private bool doubleJumped;

    private Animator animator;
    Rigidbody2D astroBody;
    public Transform groundCheck;

    public LayerMask whatisGround;


    void Start()
    {
        astroBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Application.targetFrameRate = 60;

    }

    void Update()
    {

      isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatisGround);

       // move player
       float MoveX = SimpleInput.GetAxis("Horizontal");
       astroBody.velocity = new Vector2(MoveX * speedAmount, astroBody.velocity.y);
       animator.SetFloat("Speed", Mathf.Abs(SimpleInput.GetAxis("Horizontal")));

        // for the player rotation
        if (SimpleInput.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }

        else if (SimpleInput.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }

    // check if ground
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            doubleJumped = false;
            Jumping = false;
            animator.SetBool("isJumping", false);

        }
    } 

    public void Jump()
    {
        // single jump
        if(isGrounded)
        {
            Jumping = true;
            isGrounded = false;
            astroBody.velocity = new Vector3(astroBody.velocity.x, jumpAmount);
            animator.SetBool("isJumping", true);
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
        }

        // double jump
        if (doubleJumped)
        {
            doubleJumped = false;
            astroBody.velocity = new Vector3(astroBody.velocity.x, jumpAmount);
            animator.SetBool("isJumping", true);
        }
    }


    void EnableDoubleJump()
    {
        doubleJumped = true;
    }

}
