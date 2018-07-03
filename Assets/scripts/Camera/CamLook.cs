/*CamLook.cs - Abraham Schultz- July 2018
 * 
 * Script to control where camera looks. should rotate on a pivot.
 * The pivot should be rig that eventually can contain a body or torso.
 * 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour {
    
    //variables for mouse movement
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity;
    public float smoothing;

    
    public Transform target; // target to have camera look at

    //game objects
    GameObject playerView;
    GameObject player;
    GameObject mainCam;




	// Use this for initialization
	void Start () {
        
        Cursor.lockState = CursorLockMode.Locked;
        mainCam = GameObject.Find("Main Camera");
        playerView = GameObject.Find("playerView");

        player =  GameObject.Find("Player");



    } // end start
	
	// Update is called once per frame
	void Update () {

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y , 1f / smoothing);
        mouseLook += smoothV;
        
        mainCam.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x , player.transform.up);



        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

	} // end update

} // end camLook
