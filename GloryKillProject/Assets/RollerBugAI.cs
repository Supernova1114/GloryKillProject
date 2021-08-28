using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBugAI : MonoBehaviour
{


    public Rigidbody2D body;
    public Animator animator;
    private Collider2D circleColl;
    private Collider2D boxColl;
    [SerializeField]
    private Collider2D headColl;
    public float forceX;

    public GameObject player;
    public float force;
    public float maxVelocity;
    public bool angry = false;


    // Start is called before the first frame update
    void Start()
    {
        circleColl = GetComponent<CircleCollider2D>();
        boxColl = GetComponent<BoxCollider2D>();
       

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
                body.angularVelocity = 2000 * -(player.transform.position - transform.position).normalized.x;
            }
            
        }
        
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

    
    private IEnumerator testCase()
    {
        float temp = 1f;


        yield return new WaitForSeconds(5);

        angry = true;

        yield return new WaitForSeconds(8);

        angry = false;
        StartCoroutine(TransformBug(false));

        //wait for transform to finnish
        yield return new WaitForSeconds(1.5f);

        angry = true;

        yield return new WaitForSeconds(8);

        angry = false;

        StartCoroutine(TransformBug(true));
        yield return new WaitForSeconds(2);

        angry = true;

        yield return new WaitForSeconds(8);

        angry = false;




        /*yield return new WaitForSeconds(temp);

        StartCoroutine(TransformBug(true));

        yield return new WaitForSeconds(temp);

        StartCoroutine(TransformBug(false));

        yield return new WaitForSeconds(temp);

        StartCoroutine(TransformBug(true));

        yield return new WaitForSeconds(temp);

        StartCoroutine(TransformBug(false));

        yield return new WaitForSeconds(temp);

        StartCoroutine(TransformBug(true));

        yield return new WaitForSeconds(temp);

        StartCoroutine(TransformBug(false));

        yield return new WaitForSeconds(temp);

        StartCoroutine(TransformBug(true));*/

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
