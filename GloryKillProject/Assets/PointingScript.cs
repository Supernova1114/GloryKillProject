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

    PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        /*mousePos = (Vector2)cameraCurr.ScreenToWorldPoint(Input.mousePosition);

        transform.up = (mousePos - transform.position)*/
        currentVelocity = body.velocity;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );*/

        Vector2 slopeVect = (mousePosition - (Vector2)transform.position);

        if (!PlayerMovement.isWalking())
        {
            slopeVect = Vector2.SmoothDamp(transform.right, slopeVect, ref currentVelocity, smoothTime, maxSpeed);
        }
        else
        {
            slopeVect = Vector2.SmoothDamp(transform.right, transform.localPosition + Vector3.down, ref currentVelocity, 0.03f, maxSpeed);
        }


        float rotation = Mathf.Rad2Deg * Mathf.Atan2(slopeVect.y,slopeVect.x);

        print(movement.gameObject.transform.rotation.eulerAngles.y);



        transform.rotation = Quaternion.Euler(0, movement.gameObject.transform.rotation.eulerAngles.y, rotation);


        

        

    }
}
