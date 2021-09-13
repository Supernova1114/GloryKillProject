using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GhostAI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
        
    }

    public void handleDie()
    {
        print(gameObject.name + " died");
        GameObject.Destroy(gameObject, 0);
    }

    public void handleStagger()
    {
        print(gameObject.name + " staggered");

    }


}
