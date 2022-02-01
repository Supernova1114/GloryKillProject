using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D body;
    [SerializeField]
    CharacterController2D characterController2D;


    [SerializeField]
    private float hurtTime = 2;
    private float nextHurtTime = 0;

    [SerializeField]
    private float hurtForce = 0;
    //private Vector2 hurtForce;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag("Enemy"))
        {

            if (Time.time > nextHurtTime)
            {
                nextHurtTime = Time.time + hurtTime;
                //print("Enemy Hurt Player");

                //do hurt


                HurtPlayer(collider);
            }
        }
    }


    private void HurtPlayer(Collider2D collider)
    {
        Vector2 tempVect = (transform.position - collider.transform.position).normalized;
        body.AddForce(tempVect * hurtForce);
    }

}
