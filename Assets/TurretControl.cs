/* TurretControl.cs - Abraham Schultz - August 2018;
 * 
 * Written for Inflection points Arts and sciences
 * 
 * 
 * This is the script to controll the behavior of the turret game object prefab
 * 
 * 
 *  
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public Transform bulletSpawn;    // location to spawn bullet
    public GameObject bulletPrefab; // bullet prefab to be used  
    public float TimeBewtween;    // float to count time between shots fired
    public float ShotTimer;     // float to set the time between shots fired

    //******************************************************************************************************************************
    // Use this for initialization
    void Start()
    {
        TimeBewtween = 0;
       // StartCoroutine(BulletFrequency());
    }

    private void Update()
    {
        TimeBewtween += Time.deltaTime;


        if (TimeBewtween >= ShotTimer)
        {

            Fire();
            TimeBewtween = 0;

        }
    }
    //******************************************************************************************************************************


    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    } // end Fire
      //******************************************************************************************************************************
} // end TurretControl
