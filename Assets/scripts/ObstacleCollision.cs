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

        // if obstacle hits pet, this will eventually never happen and only the player will be able to hit obstacles
        if (other.gameObject.name == "Pet")
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
}
