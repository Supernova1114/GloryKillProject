using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingScript : MonoBehaviour
{
    public Camera cameraCurr;

    public float smoothTime;
    public Rigidbody2D body;
    Vector2 currentVelocity;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*mousePos = (Vector2)cameraCurr.ScreenToWorldPoint(Input.mousePosition);

        transform.up = (mousePos - transform.position)*/
        currentVelocity = body.velocity;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );

        if (!PlayerMovement.isWalking())
        {
            transform.up = Vector2.SmoothDamp(transform.up, direction, ref currentVelocity, smoothTime, maxSpeed);
        }
        else
        {
            transform.up = Vector2.SmoothDamp(transform.up, transform.localPosition + Vector3.down, ref currentVelocity, 0.03f, maxSpeed);
        }

        //transform.up = direction;

    }
}
