using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject foot; //Empty GameObject for detection of ground
    [SerializeField]
    private float footRadius; //Radius of ground detection
    [SerializeField]
    private LayerMask groundLayers; //Layers chosen to be detected as ground
    private bool isGrounded = false; //If the player is grounded or not

    [SerializeField]
    private float moveSpeed; //Horizontal movement speed of player

    [SerializeField]
    private float jumpSpeed; //Vertical speed for player jump
    [SerializeField]
    private float startJumpTime;
    private float jumpTime;

    private Rigidbody2D body; //Player rigidbody

    private float horizontal; //Horizontal input axis for controls
    private int lastDirection = 0;

    [SerializeField]
    private float dashCooldownInit; //Initial cooldown for dash
    private float dashCooldown; //Current cooldown for dash
    [SerializeField]
    private float dashSpeed; //Horizontal speed of dash
    [SerializeField]
    private float startDashTime;
    private float dashTime;
   

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        dashCooldown = 0;
        dashTime = 0;
        jumpTime = 0;
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //Handle jump input
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpTime <= 0 && isGrounded)
            {
                jumpTime = startJumpTime;
            }
        }

        //Handle dash input
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashTime <= 0 && dashCooldown <= 0)
            {
                if (Mathf.Abs(horizontal) > 0)
                {
                    lastDirection = (int)horizontal;
                    dashTime = startDashTime;
                    dashCooldown = dashCooldownInit;
                }
                
            }
            
        }

        if (dashCooldown > 0)
            dashCooldown -= Time.deltaTime;
        if (dashTime > 0)
            dashTime -= Time.deltaTime;
        if (jumpTime > 0)
            jumpTime -= Time.deltaTime;

        

    }


    private void FixedUpdate()
    {
        //Handle ground detection -------------------
        Collider2D[] colliderList = Physics2D.OverlapCircleAll(foot.transform.position, footRadius, groundLayers.value);

        if (colliderList.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //-------------------------------------------

        //Handle left and right movement
        body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);

        //Handle jumping
        if (jumpTime > 0)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }

        //Handle dashing
        if (dashTime > 0)
        {
            body.velocity = new Vector2(lastDirection * dashSpeed, body.velocity.y);
        }

        
    }


}
