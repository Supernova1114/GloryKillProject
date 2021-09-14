using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterArmController : MonoBehaviour
{

    private UnityEngine.U2D.SpriteShapeController spriteShapeController;
    private UnityEngine.U2D.Spline spline;

    public GameObject armObject;
    public GameObject knob;

    public float armDistance = 0;

    public LayerMask layerMask;

    public int armCount = 0;

    
    private List<GameObject> armList = new List<GameObject>();

    private List<UnityEngine.U2D.Spline> splineList = new List<UnityEngine.U2D.Spline>();

    private List<RaycastHit2D> hitList = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<armCount; i++)
        {
            armList.Add(Instantiate(armObject, Vector2.zero, Quaternion.Euler(0,0,0)));
            spriteShapeController = armList[i].GetComponent<UnityEngine.U2D.SpriteShapeController>();
            splineList.Add(spriteShapeController.spline);
        }

        for (int i = 0; i < splineList.Count; i++)
        {
            splineList[i].SetPosition(1, transform.position + new Vector3(0, 0, 1));
        }



    }

 

    // Update is called once per frame

    //int tempCount = 0;
    void Update()
    {
        /*if (tempCount > hitList.Count)
        {
            for (int i=0; i<tempCount - hitList.Count; i++)
            {
                splineList[i].SetPosition(1, transform.position * 0.1f);
            }
        }*/

        for (int i=0; i<splineList.Count; i++)
        {
            splineList[i].SetPosition(0, transform.position);
        }

        //fix based on amount of arms
        for (int i=0; i<360; i += 12)//must make the hitlistthe same amount as the arm count FIX
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2( Mathf.Cos(Mathf.Deg2Rad * i), Mathf.Sin(Mathf.Deg2Rad * i) ), armDistance, layerMask.value);
            hitList.Add(hit);

            
        }

        
        for (int i=0; i<splineList.Count && i<hitList.Count; i++)
        {
            
            //Vector2 to get rid of the z
            float distance = ((Vector2)splineList[i].GetPosition(0) - (Vector2)splineList[i].GetPosition(1)).magnitude;
            //print(distance);

            //resets if too long
            if (distance > armDistance)
            {
                splineList[i].SetPosition(1, transform.position + new Vector3(0, 0, 1));
            }
            else
            {
                //if not being used
                if (distance <= 2f)
                if (hitList[i].collider != null)
                {

                    splineList[i].SetPosition(1, hitList[i].point);
                }

            }



            //Instantiate(knob, hitList[i].point, transform.rotation);
            //print(splineList[i].GetPosition(1));
            //tempCount++;
        }



        //print(splineList.Count);
        //print(hitList.Count);
        //print("DONE");
        hitList.Clear();
    }
}
