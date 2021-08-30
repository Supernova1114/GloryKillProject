using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBugAI : MonoBehaviour
{


    public Rigidbody2D body;
    public Animator animator;

    public Transform returnMarker;

    [SerializeField]
    private Collider2D circleColl;
    [SerializeField]
    private Collider2D boxColl;
    [SerializeField]
    private Collider2D headColl;

    //public float forceX;

    public GameObject player;
    public float force;
    public float maxVelocity;

    public float rollAngularVelocity = 4;

    public bool angry = false;

    private bool isWaitingForCoroutine = false;

    public float shotCooldownTime;
    private float nextShotTime = 0;

    //for smoothDamp aiming
    [Header("SmoothDamp Aim")]
    [Space]
    public float smoothTime;
    public float maxSpeed;
    public GameObject firePoint;
    public GameObject bullet;
    private Vector2 currentVelocity;




    // Start is called before the first frame update
    void Start()
    {
       //firePoint.transform.rotation = 

        EnableHeadColl(0);

        StartCoroutine(testCase());
    }

    // Update is called once per frame
    void Update()
    {
        if (angry)
        {
            //relative to player and roller bug
            Vector2 direction = player.transform.position - transform.position;
            //relative to player and firePoint
            Vector2 firePointDir = player.transform.position - firePoint.transform.position;

            if (!animator.GetBool("ballMode"))
            {
                body.AddForce(new Vector2(direction.normalized.x, 0) * force);
                body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);

                //change direction to face player
                if (direction.normalized.x > 0)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                else
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                //calculate shot direction with smoothDamp
               
                Vector2 slopeVect = Vector2.SmoothDamp(firePoint.transform.right, firePointDir, ref currentVelocity, smoothTime, maxSpeed);
                float rotation = Mathf.Rad2Deg * Mathf.Atan2(slopeVect.y, slopeVect.x);
                firePoint.transform.rotation = Quaternion.Euler(0f, 0f, rotation);



                //shoot with coolDown
                if (Time.time > nextShotTime)
                {
                    nextShotTime = Time.time + shotCooldownTime;
                    Instantiate(bullet,firePoint.transform.position, firePoint.transform.rotation);

                }


            }
            else
            {
                body.angularVelocity = rollAngularVelocity * -direction.normalized.x;
            }
            
        }
        
    }

    private IEnumerator ReturnToFloor()
    {
        body.constraints = RigidbodyConstraints2D.FreezePosition;

        yield return new WaitForSeconds(2);

        angry = false;

        

        transform.localPosition = returnMarker.localPosition;

        yield return new WaitForSeconds(2);

        body.constraints = RigidbodyConstraints2D.FreezeRotation;

        body.constraints = RigidbodyConstraints2D.None;

        isWaitingForCoroutine = false;
        
    }

    private IEnumerator TransformBug(bool ballMode)
    {
        //yield return new WaitForSeconds(2);

        /*yield return new WaitForSeconds(2);
        body.AddForce(new Vector2(forceX, 0.5f));
        //body.AddRelativeForce(new Vector2(forceX, 0.5f));
        yield return new WaitForSeconds(1.5f);*/

        if (ballMode == false)
        {
            body.freezeRotation = true;

            transform.rotation = Quaternion.Euler(0, 0, 0);

            //enables headColl and bodyColl
            animator.SetBool("ballMode", false);

            yield return new WaitForSeconds(1.5f);


            //angry = true;
        }
        else
        {
            //transform back to ball;
            //yield return new WaitForSeconds(5f);
            //angry = false;

            animator.SetBool("ballMode", true);

            yield return new WaitForSeconds(1.5f);

            body.freezeRotation = false;

            //angry = true;
        }
        isWaitingForCoroutine = false;
    }

    
    //testRun
    private IEnumerator testCase()
    {
        angry = false;

        yield return new WaitForSeconds(5);

        for (int i=0; i<4; i++)
        {

            
            isWaitingForCoroutine = true;
            StartCoroutine(TransformBug(false));
            while (isWaitingForCoroutine)
            {
                yield return new WaitForSeconds(0.1f);
            }

            angry = true;

            yield return new WaitForSeconds(12);

            angry = false;

            isWaitingForCoroutine = true;
            StartCoroutine(TransformBug(true));
            while (isWaitingForCoroutine)
            {
                yield return new WaitForSeconds(0.1f);
            }

            angry = true;

            yield return new WaitForSeconds(15);

            isWaitingForCoroutine = true;
            StartCoroutine(ReturnToFloor());
            while (isWaitingForCoroutine)
            {
                yield return new WaitForSeconds(0.1f);
            }





        }


    }




    //0 or 1
    public void EnableBodyColl(int b)
    {
        if (b == 1)
            boxColl.enabled = true;
        else
            boxColl.enabled = false;

    }

    //0 or 1
    public void EnableHeadColl(int b)
    {
        if (b == 1)
            headColl.enabled = true;
        else
            headColl.enabled = false;
    }


    




}
