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
    [SerializeField]
    private float force;
    [SerializeField]
    private float maxVelocity;

    private bool angry = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (angry)
        {
            body.AddForce((player.transform.position - transform.position).normalized * force);
            body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
        }
        
    }



    private IEnumerator MakeAngry()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, 8);//dist a little more than trigger

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            //print(hit.collider.gameObject.name);

            angry = true;
            animator.SetTrigger("MakeAngry");
            yield return new WaitForSeconds(10);

            animator.SetBool("Stagger", true);

            angry = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && flag)
        {
            flag = false;
            StartCoroutine(MakeAngry());
        }
    }


}
