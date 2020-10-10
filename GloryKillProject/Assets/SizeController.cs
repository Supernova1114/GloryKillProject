using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SizeController : MonoBehaviour
{
    public CinemachineTargetGroup.Target[] targetGroup;
    public GameObject rollerBug;

    // Start is called before the first frame update
    void Start()
    {
        //ArrayList ghosts = new ArrayList();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //targetGroup[0] = enemies[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
