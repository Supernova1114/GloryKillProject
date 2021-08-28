using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePadController : MonoBehaviour
{
    [SerializeField]
    private float coolDownTime = 5;
    private float nextBounceTime = 0;
    //private float coolDown;
    [SerializeField]
    private float bounceForce = 0;


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
        if (Time.time > nextBounceTime)
        {
            if (collision.CompareTag("Enemy"))
            {
                nextBounceTime = Time.time + coolDownTime;

                collision.attachedRigidbody.AddForce(new Vector2(0, bounceForce));
            }
        }
        
    }

}
