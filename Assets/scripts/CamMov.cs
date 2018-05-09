/*CammMov.cs
 * Abraham Schultz
 * 
 * Last edited 5/9//2018
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
    public Vector3 startCam;       // starting point of cam

    // Use this for initialization
    void Start () {
     
         mainCamera = GameObject.Find("Main Camera");
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
	}
	
	// Update is called once per frame
	void Update () {
        camPos = GetComponent<Rigidbody>().position.z;
        if (camPos > 16.0f)                     // if cam gets to certain point, then send back to begining.
        {

           
        mainCamera.transform.Translate(0, -3.037822f, -16);    // hardcoded starting location for debugging
            camPos = 0;

        }
		
	}
}
