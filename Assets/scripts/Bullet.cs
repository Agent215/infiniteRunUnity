/*Bullet.cs -Abraham Schultz- August 2018
 * 
 * script for unity to control bullet behavior
 * 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    public GameObject explosionPreFab;

    // Update is called once per frame
    void Update()
    {

        //destroys bullets after 5 seconds
        Destroy(this.gameObject, 5);
    }

    void OnTriggerEnter(Collider col)
    {
        //check to see if it is hitting your pet or hover bike 
        if (col.gameObject.tag == "obstacle")
        {
            //other wise destroy bullet and whatever it hit
            Destroy(col.gameObject);

            Instantiate(explosionPreFab, gameObject.transform.position, Quaternion.identity);
            //add an explosion or something
            //destroy the projectile that just caused the trigger collision
            Destroy(gameObject);
        }
        else
        {
            if (col.gameObject.tag == "Enemy")
            {
                //other wise destroy bullet and whatever it hit
                Destroy(col.gameObject);

                Instantiate(explosionPreFab, gameObject.transform.position, Quaternion.identity);
                //add an explosion or something
                //destroy the projectile that just caused the trigger collision
                Destroy(gameObject);

            }

        } 
   
    }// end OnTriggerEnter

} // end Bullet
