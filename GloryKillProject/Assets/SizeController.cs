using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SizeController : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public CinemachineTargetGroup group;
    public GameObject rollerBug;

    // Start is called before the first frame update
    void Start()
    {
        //ArrayList ghosts = new ArrayList();
        group.AddMember(rollerBug.transform, 1, 0);

        //targetGroup[0] = enemies[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // if (group.BoundingBox != null)
        //cam.m_Lens.OrthographicSize = Camera.current.WorldToViewportPoint( group.BoundingBox.size ).magnitude;
    }
}
