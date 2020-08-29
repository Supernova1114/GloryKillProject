using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloryKill : MonoBehaviour
{
    private RaycastHit2D hit;
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            hit = Physics2D.Raycast(transform.position, Vector2.right, 2);
            
            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("ghostStag"))
                {
                    StartCoroutine(PlayGlory());
                }
            }
        }
    }

    private IEnumerator PlayGlory()
    {
        while ( (hit.collider.transform.position - transform.position).magnitude > 1.5)
        {
            transform.position += new Vector3(0.1f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        print("play animation");

        Destroy(hit.collider.gameObject, 0);
        animator.SetBool("Ghost", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Ghost", false);

    }

}
