using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

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

    private static bool isPointingRight;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        Vector2 slopeVect = (mousePosition - (Vector2)transform.position);

        if (GloryKill.Status())
        {
            slopeVect = transform.localPosition + Vector3.down;
            //slopeVect = Vector2.SmoothDamp(transform.right, transform.localPosition + Vector3.down, ref currentVelocity, 0.03f, maxSpeed);
        }
        else
        {
            slopeVect = Vector2.SmoothDamp(transform.right, slopeVect, ref currentVelocity, smoothTime, maxSpeed);
        }


        if (!GloryKill.Status()) 
        {
            float rotation = Mathf.Rad2Deg * Mathf.Atan2(slopeVect.y, slopeVect.x);


            if (rotation < 90 && rotation > -90)
            {

                gun.transform.localRotation = Quaternion.Euler(0, 0, 0);
                isPointingRight = true;


            }
            else
            {
                gun.transform.localRotation = Quaternion.Euler(180, 0, 0);
                isPointingRight = false;

            }


            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }

        

    }


    public static bool IsPointingRight()
    {
        return isPointingRight;
    }

}
