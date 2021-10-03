using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SizeController : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public CinemachineTargetGroup group;
    public GameObject rollerBug;
    [SerializeField]
    private float normalOrthoSize = 6;
    [SerializeField]
    private float gloryKillOrthoSize = 2;
    [SerializeField]
    private float sizeLerpInterval = 0.1f;

    private bool showGloryKillCamera = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //ArrayList ghosts = new ArrayList();
        //group.AddMember(rollerBug.transform, 1, 0);////////////////////////

        //targetGroup[0] = enemies[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
       // if (group.BoundingBox != null)
        //cam.m_Lens.OrthographicSize = Camera.current.WorldToViewportPoint( group.BoundingBox.size ).magnitude;

        if (showGloryKillCamera)
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, gloryKillOrthoSize, sizeLerpInterval);
        }
        else
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, normalOrthoSize, sizeLerpInterval);
        }
    }

    public void setGloryKillCam(bool b)
    {
        showGloryKillCamera = b;
    }

}
