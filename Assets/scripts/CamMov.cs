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

    
    public float camPos;          // current point of camera 
    public GameObject mainCamera;  // main cam
    private Vector3 spawnLocation;  // location cam spawns at after resetting 
    private GameObject ground;      // hold ground object
    private Vector3 groundStart;    //exact location where the ground object begins
    private float groundZ;  // starting point in the z axis for ground
    private float groundY;  // should not change
    private float groundX;  // should not change


    //******************************************************************************************************************************
    // Use this for initialization
    void Start () {
                                     
        mainCamera = GameObject.Find("Main Camera");                // get the camera object
        spawnLocation = mainCamera.transform.position;              // get starting position of cam
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);  // move the camera foward 
        ground = GameObject.Find("ground(Clone)");
    } // end start

    //******************************************************************************************************************************
    // Update is called once per frame
    void Update() {

        

        groundX = ground.transform.position.x;
        groundY = ground.transform.position.y;
        camPos = mainCamera.transform.position.z;
        groundZ = ground.transform.position.z - 2* ground.transform.position.z;  // starting point in z axis
        groundStart = new Vector3(groundX, groundY, groundZ);        


        if (camPos > ground.transform.position.z ) {


            mainCamera.transform.position = (groundStart);  // move to begining of ground
        }




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
