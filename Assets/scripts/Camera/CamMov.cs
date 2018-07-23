/*CamMov.cs
 * Abraham Schultz
 * 
 * Last edited 5/21//2018
 * 
 * This is a script to move the camera in an endless run down a hallway.
 * In this case because the camera will eventually be replaced with a VR camera rig, it can also be
 * thought of as the player. So that this is intended to be a first person experience.
 * 
 */

using System.Collections;
using UnityEngine;

public class CamMov : MonoBehaviour
{

    // lerp variables to move pet smoothly based on speed of movement.
    public Transform startMarker;
    public float lerpTime;
    public float lerpDistance;

    //movements and controls
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode speedUp;
    public KeyCode slowDown;
    public int laneNumber = 2;       //  horizontal current lane camera is in. L= 1 , M=2 , R =3

    //for VR input
    private Vector2 CurrentTouch;
    float TouchX;
    float TouchY;
    public GameObject Controller;

    public float speed;

    public Vector3 camPos;          // current point of camera 
    public GameObject mainCamera;  // main camera object
    private GameObject gameControl;

    public bool controlLocked = false; // to prevent rapid button mashing of controls. when false controls work.


    //******************************************************************************************************************************
    // Use this for initialization
    void Start()
    {
        //assign objects from hiearchy
        mainCamera = GameObject.Find("Main Camera");
        gameControl = GameObject.Find("Game Control");

        //initialize variables
        lerpTime = .25f;
        lerpDistance = 2.0f;
        speed = gameControl.GetComponent<HallCam>().outputSpeed;


        //initialize camera position at origin
        camPos = mainCamera.transform.position;

    } // end start

    //******************************************************************************************************************************

    // Update is called once per frame
    void Update()
    {

        TouchX = GvrControllerInput.TouchPos.x;
        TouchY = GvrControllerInput.TouchPos.y;

        //update camera position
        camPos = mainCamera.transform.position;


        // ------------------------Movement and Controls----------------------------------------------

        //move left
        if (GvrControllerInput.ClickButton && (laneNumber > 1) && (!controlLocked) && (TouchX < .5))
        {
            StartCoroutine(MoveSmoothley(mainCamera.GetComponent<Transform>(),
                       mainCamera.GetComponent<Transform>().position,
                       new Vector3(camPos.x, camPos.y,
                       camPos.z + lerpDistance), lerpTime));

            laneNumber -= 1;
            controlLocked = true;
        }// end if

        //move right
        if (GvrControllerInput.ClickButton && (laneNumber < 3) && (!controlLocked) && (TouchX > .5))
        {

            StartCoroutine(MoveSmoothley(mainCamera.GetComponent<Transform>(),
                         mainCamera.GetComponent<Transform>().position,
                         new Vector3(camPos.x, camPos.y,
                        camPos.z - lerpDistance), lerpTime));

            laneNumber += 1;
            controlLocked = true;
        }// end if


        //speed up
        if (GvrControllerInput.IsTouching && !(speed > 10) && (TouchY < .3f))
        {

            speed += .02F;
            gameControl.GetComponent<HallCam>().SetSpeed(speed);

        }// end if

        //slow down
        if (GvrControllerInput.IsTouching && !(speed < 1) && (TouchY > .7f))
        {
            speed -= .02F;
            gameControl.GetComponent<HallCam>().SetSpeed(speed);

        }// end if


        //stop coroutines after player moves 
        if (!controlLocked) { StopAllCoroutines(); }

    } //end update


    //******************************************************************************************************************************

    // this method moves the camera object smoothley between two Vector3 points.  Time here is the time the transition takes

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


}// end CamMov




