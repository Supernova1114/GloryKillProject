using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBugHead : MonoBehaviour
{
    public Animator rollerBugAnimator;

    private int headHit = 0;

    public float headHitCooldowsn;
    private float currentHeadHitCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentHeadHitCooldown -= Time.fixedDeltaTime;

        if (currentHeadHitCooldown <= 0)
        {
            rollerBugAnimator.SetInteger("HeadHit", 0);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If head is touched by player and player is moving downwards
        if (collision.CompareTag("Player") && collision.attachedRigidbody.velocity.y < 0)
        {
            if (headHit < 2)
            {
                headHit++;

                rollerBugAnimator.SetInteger("HeadHit", headHit);

                currentHeadHitCooldown = headHitCooldowsn;

            }
            else
            {
                headHit = 0;
            }
        }
    }


}
