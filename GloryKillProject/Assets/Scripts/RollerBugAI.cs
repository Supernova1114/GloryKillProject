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

    public GameObject rollerBugTestHead;



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
                

                //change direction to face player
                if (direction.normalized.x > 0)
                {
                    //rollerBugTestHead.transform.rotation = Quaternion.Euler(180, 180, rollerBugTestHead.transform.rotation.eulerAngles.z);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    //rollerBugTestHead.transform.rotation = Quaternion.Euler(0, 0, rollerBugTestHead.transform.rotation.eulerAngles.z);

                }

                //calculate shot direction with smoothDamp

                Vector2 slopeVect = Vector2.SmoothDamp(firePoint.transform.right, firePointDir, ref currentVelocity, smoothTime, maxSpeed);
                float rotation = Mathf.Rad2Deg * Mathf.Atan2(slopeVect.y, slopeVect.x);
                firePoint.transform.rotation = Quaternion.Euler(0f, 0f, rotation);

                //TEMP
                //Rollerbug test head look at player
                //Vector2 testHeadDir = -(player.transform.position - rollerBugTestHead.transform.position);
                //float rot = Mathf.Rad2Deg * Mathf.Atan2(testHeadDir.y, testHeadDir.x);

                //rollerBugTestHead.transform.rotation = Quaternion.Euler(rollerBugTestHead.transform.rotation.eulerAngles.x, rollerBugTestHead.transform.rotation.eulerAngles.y, rot);
                
                
                



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
        
    }

    
    //testRun the AI
    private IEnumerator testCase()
    {
        angry = false;

        yield return new WaitForSeconds(5);

        for (int i=0; i<4; i++)
        {

            
            

            yield return StartCoroutine(TransformBug(false));

            angry = true;

            yield return new WaitForSeconds(12);

            angry = false;
            
            yield return StartCoroutine(TransformBug(true));

            angry = true;

            yield return new WaitForSeconds(15);

            
            yield return StartCoroutine(ReturnToFloor());
            





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
