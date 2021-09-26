using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthCreatureAI : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private GameObject followTarget;
    [SerializeField]
    private float walkSpeed = 0;

    void Start()
    {
               
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = (followTarget.transform.position - transform.position).normalized;
        body.velocity = new Vector2(targetPosition.x * walkSpeed, body.velocity.y);

        transform.rotation = Quaternion.Euler(0, Mathf.Rad2Deg * Mathf.Acos(targetPosition.x > 0 ? -1 : 1), 0);
    }
}
