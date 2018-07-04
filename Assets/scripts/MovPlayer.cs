/*MovPlayer.cs -Abraham Schultz-July2018
 * 
 *Scipt to move the player rig  , should move the same as camera.
 * 
 * 
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour {


    //objects in game
    public GameObject player;
    public GameObject gameControl;
    public Transform playerTransform;

    public Vector3 playerPos;

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
    void Start()
    {

        //initialize variables
        lerpTime = .25f;
        lerpDistance = 2.0f;

        //get game objects
        gameControl = GameObject.Find("Game Control");

        player = GameObject.Find("Player");
        playerTransform = player.transform;

        playerPos = player.transform.position;

    }// end start

    //******************************************************************************************************************************

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;


        //move left
        if (Input.GetKeyDown(moveLeft) && (laneNumber > 1) && (!controlLocked))
        {
            StartCoroutine(MoveSmoothley(player.GetComponent<Transform>(),
                       player.GetComponent<Transform>().position,
                       new Vector3(playerPos.x, playerPos.y,
                       playerPos.z + lerpDistance), lerpTime));

            laneNumber -= 1;
            controlLocked = true;
        }// end if

        //move right
        if (Input.GetKeyDown(moveRight) && (laneNumber < 3) && (!controlLocked))
        {

            StartCoroutine(MoveSmoothley(player.GetComponent<Transform>(),
                         player.GetComponent<Transform>().position,
                         new Vector3(playerPos.x, playerPos.y,
                        playerPos.z - lerpDistance), lerpTime));

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

}// end MovPlayer
