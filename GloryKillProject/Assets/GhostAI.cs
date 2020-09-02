using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GhostAI : MonoBehaviour
{
    [SerializeField]
    private protected Animator animator;
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


    public void TriggerCollision(Collider2D collision)
    {
        StartCoroutine(HandleCollision(collision));
    }

    private IEnumerator HandleCollision(Collider2D collision)
    {
        print("Collidd");
        /*if (collision.gameObject.CompareTag("Player") && flag)
        {
            //print("aashdashdkj");
            flag = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized);

            if (hit.collider.CompareTag("Player"))
            {
                //print("jshakhdskjahdkas");
                animator.SetTrigger("MakeAngry");
                yield return new WaitForSeconds(2);

                animator.SetBool("Stagger", true);
                yield return new WaitForSeconds(2);

            }
            flag = true;//needs change

        }*/
        yield return new WaitForSeconds(0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("heyy");
    }


}
