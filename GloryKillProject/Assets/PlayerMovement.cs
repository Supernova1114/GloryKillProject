using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    //public Animator armAnimator;


    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool dash = false;

    private static bool isGloryKilling = false;

    public float dashCooldownInterval;
    private float currentDashCooldown = 0;



    private void Update()
    {
        isGloryKilling = GloryKill.Status();


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (!isGloryKilling)
        {
            animator.SetFloat("HorizontalRaw", Mathf.Abs(horizontalMove));
            //armAnimator.SetFloat("HorizontalRaw", Mathf.Abs(horizontalMove));
        }
        

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Dash"))
        {
            if (currentDashCooldown <= 0)
            {
                dash = true;
                currentDashCooldown = dashCooldownInterval;

            }

        }

        currentDashCooldown -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //Move Character
        if (!isGloryKilling)
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, dash);

        jump = false;
        dash = false;
    }


}
