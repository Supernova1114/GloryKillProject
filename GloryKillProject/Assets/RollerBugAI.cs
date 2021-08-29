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



    

    // Start is called before the first frame update
    void Start()
    {
       

        EnableHeadColl(0);

        StartCoroutine(testCase());
    }

    // Update is called once per frame
    void Update()
    {
        if (angry)
        {
            if (!animator.GetBool("ballMode"))
            {
                body.AddForce(new Vector2((player.transform.position - transform.position).normalized.x, 0) * force);
                body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
            }
            else
            {
                body.angularVelocity = rollAngularVelocity * -(player.transform.position - transform.position).normalized.x;
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

        for (int i=0; i<2; i++)
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

            yield return new WaitForSeconds(12);

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
