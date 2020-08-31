using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && flag)
        {
            flag = false;
            animator.SetTrigger("MakeAngry");
            yield return new WaitForSeconds(2);
            animator.ResetTrigger("MakeAngry");

            animator.SetTrigger("Stagger");
            yield return new WaitForSeconds(2);
            animator.ResetTrigger("Stagger");
            flag = true;//needs change
        }
    }

}
