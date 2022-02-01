using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    public Rigidbody2D body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right * speed;
        Destroy(gameObject, 5);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);

        }


    }

}
