using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GhostAI : MonoBehaviour
{
    public Rigidbody2D body;

    public GameObject follow;

    public float targetSpeed;
    public float maxSpeed;
    public float smoothTime;//0 to 1
    private Vector2 currentVelocity = Vector2.zero;

    private bool isStaggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (isStaggered == false)
        {
            Vector2 targetVelocity = (follow.transform.position - transform.position).normalized * targetSpeed;
            body.velocity = Vector2.SmoothDamp(body.velocity, targetVelocity, ref currentVelocity, smoothTime, maxSpeed, Time.fixedDeltaTime);
        }
    }

    public void handleDie()
    {
        print(gameObject.name + " died");
        //GameObject.Destroy(gameObject, 0);
    }

    public void handleStagger()
    {
        print(gameObject.name + " staggered");
        isStaggered = true;
        body.gravityScale = 1;

    }


}
