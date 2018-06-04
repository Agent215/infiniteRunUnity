/*HallCam.cs- June 2018- Abraham Schultz
 * 
 * Move the tunnel objects in unity to give the illusion of an inftinte hallway
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallCam : MonoBehaviour {

    //  Walls //
    public float pos_x1;
    public float pos_x2;
    public float pos_x3;
    public GameObject Tunnel1;
    public GameObject Tunnel2;
    public GameObject Tunnel3;
    public GameObject Everything;
    public Vector3 EveryPos;
    private Vector3 SceneRotation;

    //Camera
    Camera mainCam;
    private Vector3 camPos = new Vector3(-10f, 1f, 0);
    private Vector3 camRotation;

    //velocity accuracy
    public float distance;
    public float velocity;
    public float tempo;


    public float outputSpeed;


    // Use this for initialization
    void Start () {

        //set speed harcoded for debugging
        outputSpeed = 5;

        Tunnel1 = GameObject.Find("Tunnel 1");
        Tunnel2 = GameObject.Find("Tunnel 2");
        Tunnel3 = GameObject.Find("Tunnel 3");
        Everything = GameObject.Find("Hallway");
        mainCam = Camera.main;

    } // end Start
	
	// Update is called once per frame
	void FixedUpdate () {


        mainCam.transform.position = camPos;
        // Get & Set Planes Positions //
        pos_x1 = Tunnel1.transform.position.x;
        pos_x2 = Tunnel2.transform.position.x;
        pos_x3 = Tunnel3.transform.position.x;
        Everything.transform.position = EveryPos;



        Tunnel1.transform.Translate(-outputSpeed / 20, 0, 0);
        Tunnel2.transform.Translate(-outputSpeed / 20, 0, 0);
        Tunnel3.transform.Translate(-outputSpeed / 20, 0, 0);

        if (pos_x1 < -110)
        {
            Tunnel1.transform.position = new Vector3(pos_x3 + 99.8f, 0, 0);
        }
        if (pos_x2 < -110)
        {
            Tunnel2.transform.position = new Vector3(pos_x1 + 99.8f, 0, 0);
        }
        if (pos_x3 < -110)
        {
            Tunnel3.transform.position = new Vector3(pos_x2 + 99.8f, 0, 0);
        }

    }// end FixedUpdate

} //end HallCam
