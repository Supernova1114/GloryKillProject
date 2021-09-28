using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloryKill : MonoBehaviour
{

    private RaycastHit2D hit;
    [SerializeField]
    private Animator animator;

    //public GameObject circle;

    private static bool isGloryKilling = false;

    public Rigidbody2D body;

    public GameObject armObj;
    ////////////////////////////////////////////////

    [SerializeField]
    private GameObject[] GibObjList;
    [SerializeField]
    private Vector2[] GibObjectPositions;

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, transform.right);

        if (Input.GetKeyDown(KeyCode.F) && isGloryKilling == false)
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

            //print(PointingScript.IsPointingRight());

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

            if (hit.collider != null)
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                //print(hit.collider.gameObject.name);
                if ( enemy != null && enemy.isStaggered() )
                {

                    isGloryKilling = true;
                    
                    StartCoroutine(PlayGlory(enemy.GetName()));

                }
            }
        }
    }


    private IEnumerator PlayGlory(string name)
    {
        yield return new WaitForSeconds(0);

        body.bodyType = RigidbodyType2D.Static;
        armObj.SetActive(false);

        //float dir = (hit.collider.transform.position - transform.position).normalized.x;

        /*//Walk animation yes
        animator.SetFloat("HorizontalRaw", 1);


        int iterations = 0;

        //move away from enemy
        while ( iterations < 10 && (hit.collider.transform.position - transform.position).magnitude > 1.05)//2.1
        {
            
            transform.position += new Vector3(0.05f * dir, 0, 0);
            iterations++;

            yield return new WaitForSeconds(0.01f);
        }

        iterations = 0;

        //move towards enemy
        while (iterations < 10 && (hit.collider.transform.position - transform.position).magnitude < 1.05)//2.1
        {

            transform.position += new Vector3(0.05f * -dir, 0, 0);
            iterations++;

            yield return new WaitForSeconds(0.01f);
        }*/

        //Walk animation no
        animator.SetFloat("HorizontalRaw", 0);

        Destroy(hit.collider.gameObject, 0);

        if (name.CompareTo("Ghost") == 0)
        {
            animator.SetInteger("GhostGloryKill", 1);
        }

        if (name.CompareTo("MouthCreature") == 0)
        {
            animator.SetInteger("MouthCreatureGloryKill", 1);
        }


    }

    public static bool Status()
    {
        return isGloryKilling;
    }
    
    public void EndGloryKill()
    {
        animator.SetInteger("GhostGloryKill", 0);
        animator.SetInteger("MouthCreatureGloryKill", 0);


        isGloryKilling = false;

        body.bodyType = RigidbodyType2D.Dynamic;
        armObj.SetActive(true);
    }

    public void SpawnGibs(string n)
    {
        //1
        if (n.CompareTo("MouthCreature") == 0)
        {
            Instantiate((Object)GibObjList.GetValue(1), transform.position, transform.rotation);
        }
    }

}
