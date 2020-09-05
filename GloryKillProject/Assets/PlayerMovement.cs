using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalRaw;
    private float horizontal;

    private float jumpFactor;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private float maxVelocity;
    [SerializeField]
    private float hMag;
    [SerializeField]
    private float jumpMag;

    private bool gloryKilling = false;
    private static bool isWalkingBool = false;


    public static bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //private bool flag = true;
    void Update()
    {
        if (transform.rotation.y == 0)
            facingRight = true;
        else
            facingRight = false;


        gloryKilling = GloryKill.GetGloryStatus();


        horizontalRaw = Input.GetAxisRaw("Horizontal");//0 or 1 or -1
        horizontal = Input.GetAxis("Horizontal");



        if (!gloryKilling)
        {
            //flag = true;
            animator.SetFloat("Horizontal", Math.Abs(horizontal));
        }

        if (Mathf.Abs(horizontal) > 0)
        {
            isWalkingBool = true;
            body.drag = 0;
        }
        else
        {
            isWalkingBool = false;
            body.drag = 2;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpFactor = 1;
        }
        else
        {
            jumpFactor = 0;
        }


        //print(isWalkingBool);
        /*else
        {
            if (flag)
            {
                flag = false;
                animator.SetFloat("Horizontal", 0);
            }
            
        }*/

        if (!gloryKilling)
            Move(horizontalRaw, jumpFactor);
        else
            body.velocity = Vector2.zero;

    }


    private void Move(float horzRaw, float jumpFact)
    {

        switch (horzRaw)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case -1:
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
        }

        /*body.AddForce(new Vector2(horzRaw * hMag, 0));
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);*/
        //print(body.velocity.x);
        body.AddForce(new Vector2(horzRaw * hMag, jumpFact * jumpMag));//horzRaw is the HorizontalRawInput, hMag is the magnitude of force you want
        body.velocity = new Vector2(Vector2.ClampMagnitude(body.velocity, maxVelocity).x, body.velocity.y);//brings a higher velocity down to the maxVelocity
        
    }

    public static bool isWalking()
    {
        return isWalkingBool;
    }


}
