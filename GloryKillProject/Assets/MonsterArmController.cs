using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterArmController : MonoBehaviour
{

    private UnityEngine.U2D.SpriteShapeController spriteShapeController;
    private UnityEngine.U2D.Spline spline;

    public GameObject armObject;

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
            armList.Add(Instantiate(armObject, transform.position, transform.rotation));
            spriteShapeController = armList[i].GetComponent<UnityEngine.U2D.SpriteShapeController>();
            splineList.Add(spriteShapeController.spline);
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
        for (int i=0; i<360; i += 10)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2( Mathf.Cos(Mathf.Deg2Rad * i), Mathf.Sin(Mathf.Deg2Rad * i) ), armDistance, layerMask.value);
            if (hit.collider != null)
            hitList.Add(hit);
        }

        //tempCount = hitList.Count;

        int tempCount = 0;
        for (int i=0; i<splineList.Count && i<hitList.Count; i++)
        {
            splineList[i].SetPosition(1, hitList[i].point);
            //print(splineList[i].GetPosition(1));
            tempCount++;
        }

        for (int i=tempCount; i< armList.Count; i++)
        {
            splineList[i].SetPosition(1, (Vector2)transform.position);
        }

        print("DONE");
        hitList.Clear();
    }
}
