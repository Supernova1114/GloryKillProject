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
        
    }


    private IEnumerator TransformBug()
    {
        yield return new WaitForSeconds(2);
        //body.AddForce(new Vector2(forceX, 0));
        body.AddRelativeForce(new Vector2(forceX, 0.5f));
        yield return new WaitForSeconds(1.2f);


        body.freezeRotation = true;

        transform.rotation = Quaternion.Euler(0, 0, 0);

        animator.SetTrigger("Transform");

        



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
