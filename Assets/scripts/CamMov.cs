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
   
   

    // Use this for initialization
    void Start () {
     
         mainCamera = GameObject.Find("Main Camera");
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
	}
	
	// Update is called once per frame
	void Update () {
        camPos = GetComponent<Rigidbody>().position.z;   
   
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("trigger"))
        {
            mainCamera.transform.Translate(0, -4.16822f, -22);    // hardcoded starting location for debugging

        } // end if
    }

}// end CamMov
