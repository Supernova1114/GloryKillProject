using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBugNeckController : MonoBehaviour
{
    public UnityEngine.U2D.SpriteShapeController spriteShapeController;
    private UnityEngine.U2D.Spline spline;
    public GameObject rollerBug;
    public GameObject rollerBugTestHead;
    public Transform rollerBugHeadMarker;
    private Vector2 currentVelocity = Vector2.zero;
    private Vector2 currVel = Vector2.zero;

    public float smoothTime;
    public float smoTime;



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
        spline.SetPosition(2, rollerBugTestHead.transform.position);

        

        Vector2 targetPosition = rollerBugHeadMarker.position;
        Vector2 currentPosition = rollerBugTestHead.transform.position;

        Vector2 move = Vector2.SmoothDamp(currentPosition, targetPosition + Vector2.up, ref currentVelocity, smoothTime);



        rollerBugTestHead.transform.position = move;

        Vector2 curr = spline.GetPosition(1);
        Vector2 tar = rollerBug.transform.position - -(rollerBugTestHead.transform.position - rollerBugHeadMarker.position);

        Vector2 move2 = Vector2.SmoothDamp(curr, tar, ref currVel, smoTime);

        spline.SetPosition(1, move2);


    }
}
