/*CamMov.cs
 * Abraham Schultz
 * 
 * Last edited 5/21//2018
 * 
 * This is a script to move the camera in an endless run down a hallway
 * 
 * 
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMov : MonoBehaviour {

    
    public float camPos;          // current point of camera z axis
    public GameObject mainCamera;  // main cam
    private Vector3 spawnLocation;  // location cam spawns at after resetting 

    //******************************************************************************************************************************
    // Use this for initialization
    void Start () {

    
        mainCamera = GameObject.Find("Main Camera");                // get the camera object
        spawnLocation = mainCamera.transform.position;              // get starting position of cam
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);  // move the camera foward 
	} // end start

    //******************************************************************************************************************************
    // Update is called once per frame
    void Update() {
        camPos = GetComponent<Rigidbody>().position.z;


    } //end update

    //******************************************************************************************************************************

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("trigger"))
        {
            mainCamera.transform.position = (spawnLocation);    //  resets the camera at starting location
            

        } // end if

    } // end OnTriggerEnter
    //******************************************************************************************************************************
}// end CamMov
