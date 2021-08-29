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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            if (Time.time > nextHurtTime)
            {
                if (collision.CompareTag("Enemy"))
                {
                    nextHurtTime = Time.time + hurtTime;
                    print("Enemy Hurt Player");

                    //do hurt


                    StartCoroutine(HurtPlayer(collision));

                }
            }
        }
    }


    private IEnumerator HurtPlayer(Collider2D collision)
    {
        characterController2D.setMovementSmoothing(0.2f);
        Vector2 tempVect = (transform.position - collision.transform.position).normalized;
        body.AddForce(tempVect * hurtForce);

        yield return new WaitForSeconds(0.1f);
        characterController2D.setMovementSmoothing();
    }

}
