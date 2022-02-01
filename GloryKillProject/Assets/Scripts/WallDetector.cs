using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private int wallColls = 0;

    private static bool isOnWall;

    [SerializeField]
    private Rigidbody2D body;


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            wallColls++;
            CheckCollisions();
            body.velocity = Vector2.zero;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            wallColls--;
            CheckCollisions();
        }
        
    }*/

    private void CheckCollisions()
    {
        if (wallColls > 0)
        {
            isOnWall = true;
        }
        else
        {
            isOnWall = false;
        }
    }

    public static bool IsOnWall()
    {
        return isOnWall;
    }

}
