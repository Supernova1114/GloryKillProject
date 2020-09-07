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
    [SerializeField]
    private GameObject gun;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*mousePos = (Vector2)cameraCurr.ScreenToWorldPoint(Input.mousePosition);

        transform.up = (mousePos - transform.position)*/
        //currentVelocity = body.velocity;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );*/

        Vector2 slopeVect = (mousePosition - (Vector2)transform.position);

        if (PlayerMovement.isWalking() || GloryKill.GetGloryStatus())
        {
            slopeVect = transform.localPosition + Vector3.down;
            //slopeVect = Vector2.SmoothDamp(transform.right, transform.localPosition + Vector3.down, ref currentVelocity, 0.03f, maxSpeed);
        }
        else
        {
            slopeVect = Vector2.SmoothDamp(transform.right, slopeVect, ref currentVelocity, smoothTime, maxSpeed);
        }


        float rotation = Mathf.Rad2Deg * Mathf.Atan2(slopeVect.y,slopeVect.x);

        //print(rotation);

        if (!PlayerMovement.isWalking() && !GloryKill.GetGloryStatus())
        {
            if (rotation < 90 && rotation > -90)
            {
                gun.transform.localRotation = Quaternion.Euler(0, 0, 0);
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                gun.transform.localRotation = Quaternion.Euler(180, 0, 0);
                player.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }


        transform.rotation = Quaternion.Euler(0f, 0f, rotation);

        /*if (PlayerMovement.facingRight)
        {
            
        }
        else
        {
            transform.rotation = Quaternion.Euler(180f, 0f, -rotation);
        }*/

        
        







    }
}
