using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalRaw;
    private float horizontal;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private float maxVelocity;
    [SerializeField]
    private float hMag;

    private bool gloryKilling = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //private bool flag = true;
    void Update()
    {
        gloryKilling = GloryKill.GetGloryStatus();


        horizontalRaw = Input.GetAxisRaw("Horizontal");//0 or 1 or -1
        horizontal = Input.GetAxis("Horizontal");



        if (!gloryKilling)
        {
            //flag = true;
            animator.SetFloat("Horizontal", Math.Abs(horizontal));
        }
        /*else
        {
            if (flag)
            {
                flag = false;
                animator.SetFloat("Horizontal", 0);
            }
            
        }*/
            

    }

    private void FixedUpdate()
    {
        if (!gloryKilling)
            Move(horizontalRaw);
        else
            body.velocity = Vector2.zero;


    }

    private void Move(float horzRaw)
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

        body.AddForce(new Vector2(horzRaw * hMag, 0));
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
        //print(body.velocity.x);

    }

}
