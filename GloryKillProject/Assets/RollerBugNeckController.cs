using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBugNeckController : MonoBehaviour
{
    public UnityEngine.U2D.SpriteShapeController spriteShapeController;
    private UnityEngine.U2D.Spline spline;
    public GameObject rollerBug;


    // Start is called before the first frame update
    void Start()
    {
        spriteShapeController = GetComponent<UnityEngine.U2D.SpriteShapeController>();
        spline = spriteShapeController.spline;
        
    }

    // Update is called once per frame
    void Update()
    {
        spline.SetPosition(0, rollerBug.transform.position);
    }
}
