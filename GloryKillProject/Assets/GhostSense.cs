using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSense : MonoBehaviour
{
    GhostAI ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponentInParent<GhostAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ai.TriggerCollision(collision);
    }
}
