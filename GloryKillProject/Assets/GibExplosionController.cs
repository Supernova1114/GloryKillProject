using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibExplosionController : MonoBehaviour
{
    [SerializeField]
    private Transform explosionTarget;
    [SerializeField]
    private float speed;

    private Rigidbody2D[] rbList;
    // Start is called before the first frame update
    void Awake()
    {
        rbList = GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D body in rbList)
        {
            body.velocity = ((Vector3)body.position - explosionTarget.position).normalized * speed;
        }
    }

    
}
