using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBugAI : MonoBehaviour
{


    public Rigidbody2D body;
    public Animator animator;
    private Collider2D circleColl;
    private Collider2D boxColl;
    public Collider2D headColl;
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

        

        StartCoroutine(TransformBug());
    }

    // Update is called once per frame
    void Update()
    {
        if (angry)
        {
            body.AddForce(new Vector2((player.transform.position - transform.position).normalized.x, 0) * force);
            body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
        }
        
    }


    private IEnumerator TransformBug()
    {
        yield return new WaitForSeconds(2);
        //body.AddForce(new Vector2(forceX, 0));
        body.AddRelativeForce(new Vector2(forceX, 0.5f));
        yield return new WaitForSeconds(1.5f);


        body.freezeRotation = true;

        transform.rotation = Quaternion.Euler(0, 0, 0);

        animator.SetTrigger("Transform");


        yield return new WaitForSeconds(2f);
        angry = true;


    }


    public void EnableBodyColl()
    {
        boxColl.enabled = true;
    }
    public void EnableHeadColl()
    {
        headColl.enabled = true;
    }




}
