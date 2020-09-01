using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GhostAI : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool flag = true;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Rigidbody2D body;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*private void Update()
    {
        body.AddForce(  (player.transform.position - transform.position).normalized* force  );
    }*/


    /*private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && flag)
        {
            flag = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized);
            //Debug.DrawLine(transform.position, (player.transform.position-transform.position).normalized);

            if (hit.collider.CompareTag("Player"))
            {
                animator.SetTrigger("MakeAngry");
                yield return new WaitForSeconds(2);

                animator.SetBool("Stagger", true);
                yield return new WaitForSeconds(2);

            }
            flag = true;//needs change

        }
    }
*/
}
