using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloryKill : MonoBehaviour
{
    private RaycastHit2D hit;
    [SerializeField]
    private Animator animator;

    public GameObject circle;

    private static bool inGlory = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inGlory == false)
        {

            hit = Physics2D.Raycast(transform.position, new Vector2( transform.position.x + 1, transform.position.y ), 2);//fix
            
            Instantiate(circle, new Vector2(transform.position.x + 1, transform.position.y), transform.rotation );//fiox
            
            if (inGlory == false && hit.collider != null)
            {
                //print(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("ghostStag"))
                {
                    inGlory = true;
                    StartCoroutine(PlayGlory());

                }
            }
        }
    }

    private IEnumerator PlayGlory()
    {
        float dir = (hit.collider.transform.position - transform.position).normalized.x;

        animator.SetFloat("Horizontal", 1);

        int iterations = 0;
        while ( iterations < 10 && (hit.collider.transform.position - transform.position).magnitude > 2.1)
        {
            
            transform.position += new Vector3(0.1f * dir, 0, 0);
            iterations++;

            yield return new WaitForSeconds(0.01f);
        }

        iterations = 0;

        while (iterations < 10 && (hit.collider.transform.position - transform.position).magnitude < 2.1)
        {

            transform.position += new Vector3(0.1f * -dir, 0, 0);
            iterations++;

            yield return new WaitForSeconds(0.01f);
        }

        animator.SetFloat("Horizontal", 0);

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
    }

}
