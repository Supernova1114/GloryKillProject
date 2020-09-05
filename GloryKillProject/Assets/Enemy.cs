using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isStaggered = false;


    [SerializeField]
    private int health;

    //public GameObject deathEffect;
    private GhostAI ghostAI;

    private void Start()
    {
        ghostAI = GetComponent<GhostAI>();
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)//fix stuff for stagger
        {
            if (isStaggered == false)
            {
                isStaggered = true;
                Die();
            }
            
        }
    }

    private void Die()//Stagger
    {
        ghostAI.body.gravityScale = 1;
        ghostAI.isAngry = false;
    }


}
