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

    public GameObject player;     // game object for player
    public GameObject mainCamera;
    public float playerPos;      // Starting position of player

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("player");
    }// end start
	
	// Update is called once per frame
	void Update () {
        playerPos = GetComponent<Rigidbody>().position.z;          //set player position
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);  // move player hardcoded for debugging 


    }// end update
} // end MovOrb
