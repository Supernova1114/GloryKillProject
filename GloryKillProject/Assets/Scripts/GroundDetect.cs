using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetect : MonoBehaviour
{

    //int layer = 0 << 8;

    private int groundColls = 0;

    private static bool isOnGround;
    // Start is called before the first frame update


    private void CheckCollisions()
    {
        if (groundColls > 0)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            groundColls++;
            CheckCollisions();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            groundColls--;
            CheckCollisions();
        }
    }

    public static bool IsOnGround()
    {
        return isOnGround;
    }

}
