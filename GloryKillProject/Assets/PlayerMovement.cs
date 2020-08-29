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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalRaw = Input.GetAxisRaw("Horizontal");//0 or 1
        horizontal = Input.GetAxis("Horizontal");


        animator.SetFloat("Horizontal", Math.Abs(horizontal));

    }

    private void FixedUpdate()
    {
        Move(horizontalRaw);


    }

    private void Move(float horzRaw)
    {
        

        body.AddForce(new Vector2(horzRaw * hMag, 0));
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
        //print(body.velocity.x);

    }

}
