using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool staggered = false;


    [SerializeField]
    private int health;

    //When the health is below this value it will stagger and replace current health with stagger health
    [SerializeField]
    private int staggerHealth;

    //public GameObject deathEffect;
    [SerializeField]
    private Component enemyAIScript;

    private void Start()
    {
        
    }

    public void TakeDamage (int damage)
    {

        if (staggered == false)
        {
            health -= damage;
        }
        else
        {
            health--;
        }

        if (health <= 0)//fix stuff for stagger
        {
            if (staggered == false)
            {
                Stagger();
            }
            else
            {
                Die();
            }
            
        }
    }

    private void Die()
    {
        enemyAIScript.SendMessage("handleDie");
    }
    
    private void Stagger()
    {
        staggered = true;
        health = staggerHealth;
        enemyAIScript.SendMessage("handleStagger");
    }

    public bool isStaggered()
    {
        return staggered;
    }


}
