using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibExplosionController : MonoBehaviour
{
    [SerializeField]
    private Transform explosionTarget;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float angularVelocity;
    [SerializeField]
    private float removeDelay;

    private Rigidbody2D[] rbList;

    private void Start()
    {

    }

    void Awake()
    {
        rbList = GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D body in rbList)
        {
            Vector2 dir = ((Vector3)body.position - explosionTarget.position).normalized;
            body.velocity = dir * speed;
            body.angularVelocity = angularVelocity * -Mathf.Sign(dir.x);
        }

        Destroy(gameObject, removeDelay);


    }


}
