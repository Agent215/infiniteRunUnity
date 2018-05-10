/*MovOrb.cs
 * Abraham Schultz
 * 
 * Last edited 5/9//2018
 * 
 * This is a script to move the player in an endless run down a hallway
 * 
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovOrb : MonoBehaviour {

    //movements and controls
    public KeyCode moveLeft;
    public KeyCode moveRight;
    //objects in game
    public GameObject player;     // game object for player
    public GameObject mainCamera;
    public float playerPos;      // Starting position of player
    public float horizVel = 0;   //hortizontal velocity of player

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("player");
    }// end start
	
	// Update is called once per frame
	void Update ()
    {
        playerPos = GetComponent<Rigidbody>().position.z;          //set player position
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 4);  // move player hardcoded for debugging 


        //if player presses left button
        if (Input.GetKeyDown(moveLeft)) {

            horizVel = -2;                //move left
            StartCoroutine(StopSlide());  // stop move
        }// end if

        //if player presses right button
        if (Input.GetKeyDown(moveRight))
        {

            horizVel = +2;                //move left
            StartCoroutine(StopSlide());  // stop move
        }// end if

    }// end update

    // method to stop player after half second of horizontal movement. 
    IEnumerator StopSlide() {

        yield return new WaitForSeconds(.5f);
        horizVel = 0;
    }// end stopSlide

} // end MovOrb
