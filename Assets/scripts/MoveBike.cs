/*MoveBike.cs -Abraham Schultz- july 2018
 * 
 * script to parent bike object to camera 
 * 
 * 
 * 
 * 
 * */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBike : MonoBehaviour {


    //objects in game
    public GameObject bike;
    public GameObject gameControl;
    public Transform bikeTransform;

    public Vector3 bikePos;

    // lerp variables to move smoothly based on speed of movement.
    public Transform startMarker;
    public float lerpTime;
    public float lerpDistance;

    //movements and controls
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode speedUp;
    public KeyCode slowDown;
    public int laneNumber = 2;       //  horizontal current lane camera is in. L= 1 , M=2 , R =3


    public bool controlLocked = false; // to prevent rapid button mashing of controls. when false controls work.

    //******************************************************************************************************************************

    // Use this for initialization
    void Start () {

        //initialize variables
        lerpTime = .25f;
        lerpDistance = 2.0f;

        //get game objects
        gameControl = GameObject.Find("Game Control");

        bike = GameObject.Find("Hoverbike");

        bikePos = bike.transform.position;

    }// end start

     //******************************************************************************************************************************

    // Update is called once per frame
    void Update () {
        bikePos = bike.transform.position;


        //move left
        if (Input.GetKeyDown(moveLeft) && (laneNumber > 1) && (!controlLocked))
        {
            StartCoroutine(MoveSmoothley(bike.GetComponent<Transform>(),
                       bike.GetComponent<Transform>().position,
                       new Vector3(bikePos.x, bikePos.y,
                       bikePos.z + lerpDistance), lerpTime));

            laneNumber -= 1;
            controlLocked = true;
        }// end if

        //move right
        if (Input.GetKeyDown(moveRight) && (laneNumber < 3) && (!controlLocked))
        {

            StartCoroutine(MoveSmoothley(bike.GetComponent<Transform>(),
                         bike.GetComponent<Transform>().position,
                         new Vector3(bikePos.x, bikePos.y,
                        bikePos.z - lerpDistance), lerpTime));

            laneNumber += 1;
            controlLocked = true;
        }// end if
    } // end update

    //******************************************************************************************************************************

    IEnumerator MoveSmoothley(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)

        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);

            yield return null;
        }//end while

        controlLocked = false;

    }  // end Move Smoothley

    //******************************************************************************************************************************
} // end MoveBike
