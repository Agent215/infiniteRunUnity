/*
 * ObstacleCollision.cs- June 2018- Abraham Schultz
 * 
 * Script for obstacle collision detection
 *
 *
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {

        // if obstacle hits bike
        if (other.gameObject.name == "Hoverbike")
        {
            StopAllCoroutines();
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
        }// end if
        
    } // end on TriggerEnter
} // end ObstacleCollision.cs
