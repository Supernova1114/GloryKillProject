using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    [SerializeField]
    private GameObject arm;

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject bulletPrefab;

    private bool isWalking = false;//takes from PlayerMovement isWalkingBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isWalking())
            isWalking = true;
        else
            isWalking = false;

        if (Input.GetMouseButtonDown(0) && !isWalking)
        {
            Shoot();
        }

        if (isWalking || GloryKill.GetGloryStatus())
            arm.SetActive(false);
        else
            arm.SetActive(true);



    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
