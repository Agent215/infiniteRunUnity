/*MovOrb.cs
 * Abraham Schultz
 * 
 * Last edited 5/9//2018
 * 
 * This is a script to move the player in an endless run down a hallway
 * Input for movment is read in from the keyboard.
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
    public float playerPos;               // Starting position of player
    public float horizVel = 0;           //hortizontal velocity of player
    public int laneNumber = 2;           // hold current lane player is in. L= 1 , M=2 , R =3
    private bool controlLocked = false; // to prevent rapid button mashing of controls. when false controls work.

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("player");
    }// end start
	
	// Update is called once per frame
	void Update ()
    {
        playerPos = GetComponent<Rigidbody>().position.z;                   //set player position
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 4);  // move player hardcoded for debugging 


        //if player presses left button and is not in left most lane already.
        if (Input.GetKeyDown(moveLeft) && (laneNumber >1) && (!controlLocked)) {

            horizVel = -2;                //move left
            StartCoroutine(StopSlide());  // stop move
            laneNumber -= 1;
            controlLocked = true;
        }// end if

        //if player presses right button and is not in right most lane already
        if (Input.GetKeyDown(moveRight) && (laneNumber <3) && (!controlLocked))
        {

            horizVel = +2;                //move left
            StartCoroutine(StopSlide());  // stop move
            laneNumber += 1;
            controlLocked = true;
        }// end if

    }// end update

    // method to stop player after half second of horizontal movement. 
    IEnumerator StopSlide() {

        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = false;
    }// end stopSlide

} // end MovOrb
