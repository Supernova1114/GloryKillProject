using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloryKill : MonoBehaviour
{

    private RaycastHit2D hit;
    [SerializeField]
    private Animator animator;

    //public GameObject circle;

    private static bool inGlory = false;

    public Rigidbody2D body;

    public GameObject armObj;

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, transform.right);

        if (Input.GetKeyDown(KeyCode.F) && inGlory == false)
        {

            if (PointingScript.IsPointingRight())
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                CharacterController2D.m_FacingRight = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                CharacterController2D.m_FacingRight = false;
            }


            hit = Physics2D.Raycast(transform.position, transform.right, 1);//2

            if (hit.collider == null)
            {
                //bool isRightTemp = CharacterController2D.m_FacingRight;

                transform.Rotate(new Vector3(0, 180, 0));
                //CharacterController2D.m_FacingRight = !isRightTemp;
                CharacterController2D.m_FacingRight = !CharacterController2D.m_FacingRight;


                hit = Physics2D.Raycast(transform.position, transform.right, 1);//2

                if (hit.collider == null)
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                    CharacterController2D.m_FacingRight = !CharacterController2D.m_FacingRight;
                }
                    

            }
                

            //Instantiate(circle, new Vector2(transform.position.x + Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y), transform.position.y), transform.rotation );//fiox

            if (inGlory == false && hit.collider != null)
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                //print(hit.collider.gameObject.name);
                if ( enemy != null && enemy.isStaggered )
                {
                    
                    inGlory = true;
                    PlayerMovement.isGloryKilling = true;
                    body.bodyType = RigidbodyType2D.Static;
                    armObj.SetActive(false);
                    StartCoroutine(PlayGlory());

                }
            }
        }
    }


    private IEnumerator PlayGlory()
    {
        float dir = (hit.collider.transform.position - transform.position).normalized.x;

        animator.SetFloat("HorizontalRaw", 1);

        body.bodyType = RigidbodyType2D.Dynamic;

        int iterations = 0;
        while ( iterations < 10 && (hit.collider.transform.position - transform.position).magnitude > 1.05)//2.1
        {
            
            transform.position += new Vector3(0.05f * dir, 0, 0);
            iterations++;

            yield return new WaitForSeconds(0.01f);
        }

        iterations = 0;

        while (iterations < 10 && (hit.collider.transform.position - transform.position).magnitude < 1.05)//2.1
        {

            transform.position += new Vector3(0.05f * -dir, 0, 0);
            iterations++;

            yield return new WaitForSeconds(0.01f);
        }

        body.bodyType = RigidbodyType2D.Static;

        animator.SetFloat("HorizontalRaw", 0);

        //print("play animation");
        

        Destroy(hit.collider.gameObject, 0);

        animator.SetBool("Ghost", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Ghost", false);

    }

    public static bool GetGloryStatus()
    {
        return inGlory;
    }
    
    void EndGloryKill()
    {
        inGlory = false;
        PlayerMovement.isGloryKilling = false;
        body.bodyType = RigidbodyType2D.Dynamic;
        armObj.SetActive(true);
    }

}
