using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform firePoint; //origin of projectile
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //le pew pew
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(projectile, firePoint.position, firePoint.rotation); // make the projectile exist
    }
}
