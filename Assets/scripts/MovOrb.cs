/* MovOrb.cs
 * Abraham Schultz
 * 
 * Last edited 5/21//2018
 * 
 * This is a script to move the player in an endless run down a hallway
 * Input for movment is read in from the keyboard or from the myo armband.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using UnityEngine.SceneManagement;

public class MovOrb : MonoBehaviour {

    //movements and controls
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode speedUp;
    public KeyCode slowDown;

    //objects in game
    public GameObject pet;                   // game object for player
    public GameObject mainCamera;
    public Vector3 playerPos;               // Starting position of player
    public float horizVel = 0;             //hortizontal velocity of player
    public int laneNumber = 2;            //  horizontal current lane pet is in. L= 1 , M=2 , R =3
    public int distanceLane = 2;         // how close or far pet is from camera. close= 1 , medium=2 , far =3
    private bool controlLocked = false; // to prevent rapid button mashing of controls. when false controls work.
    public GameObject gameControl;     // acess to the gameControl Object
    private float speed;              // for speeding up or slowing down the tunnel speed

    // lerp variables to move pet smoothly based on speed of movement.
    public Transform startMarker;
    public float lerpTime = 2.0F;
    public float lerpDistance = 2.0F;
    private float startTime;
   


    /* Myo game object to connect with.
     * This object must have a ThalmicMyo script attached.
     */
    public GameObject myo = null;
    /* The pose from the last update. This is used to determine if the pose has changed
    * so that actions are only performed upon making them rather than every frame during
    * which they are active.
    */
    private Pose _lastPose = Pose.Unknown;

    //******************************************************************************************************************************
    // Use this for initialization
    void Start()
    {
        //get game objects
        gameControl = GameObject.Find("Game Control");
        mainCamera = GameObject.Find("Main Camera");
        pet = GameObject.Find("Pet");

        //set variables
        playerPos = pet.transform.position;

        //set time and journey length for lerp
        startTime = Time.time;
       

    }// end start

    //******************************************************************************************************************************
    // Update is called once per frame
    void Update()
    {
        //update speed
        speed = gameControl.GetComponent<HallCam>().outputSpeed;

        //move pet left or right
        pet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, horizVel);
  
    

        //// Access the ThalmicMyo component attached to the Myo object.
        //ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        //// Update references when the pose becomes fingers spread or the q key is pressed.



        //// input to move ball from myo armband
        //if (thalmicMyo.pose != _lastPose)
        //{
        //    _lastPose = thalmicMyo.pose;

        //    if (thalmicMyo.pose == Pose.WaveIn)
        //    {


        //        horizVel = -2;                //move left
        //        StartCoroutine(StopSlide());  // stop move
        //        laneNumber -= 1;
        //        controlLocked = true;
        //        ExtendUnlockAndNotifyUserAction(thalmicMyo);
        //    } // end if

        //    if (thalmicMyo.pose == Pose.WaveOut)
        //    {


        //        horizVel = +2;                //move left
        //        StartCoroutine(StopSlide());  // stop move
        //        laneNumber += 1;
        //        controlLocked = true;
        //        ExtendUnlockAndNotifyUserAction(thalmicMyo);
        //    } // end if
        //}// end if

        // ------------------------Movement and Controls-------------------------------------------------------------------------------

        //move left
        if (Input.GetKeyDown(moveLeft) && (laneNumber > 1) && (!controlLocked)) {

            horizVel = +2;                //move left
            StartCoroutine(StopSlide());  // stop move
            laneNumber -= 1;
            controlLocked = true;
        }// end if

        //move right
        if (Input.GetKeyDown(moveRight) && (laneNumber < 3) && (!controlLocked))
        {

            horizVel = -2;                //move right
            StartCoroutine(StopSlide());  // stop move
            laneNumber += 1;
            controlLocked = true;
        }// end if

        // speed up
        if (Input.GetKeyDown(speedUp) && !(speed >= 10) && (!controlLocked)) {
         
        //increase speed of tunnel
        gameControl.GetComponent<HallCam>().SetSpeed(speed + 2);
         
            // if pet is close to camera
            if(distanceLane < 3)
            {


                //move the ball foward by 2, over a period of 2 seconds, 
                StartCoroutine(MovePet(pet.GetComponent<Transform>(),
                           pet.GetComponent<Transform>().position,
                           new Vector3(startMarker.position.x + lerpDistance, startMarker.position.y,
                           startMarker.position.z), lerpTime));

                controlLocked = true;                //lock control
                distanceLane += 1;
                StartCoroutine(UnLockControl(lerpTime));   // unlock after 2 seconds, 

            }// end if
        
        }// end if

        // slow down 
        if (Input.GetKeyDown(slowDown) && !(speed <= 2) && (!controlLocked))
        {

        //decrease the speed of the tunnel
         gameControl.GetComponent<HallCam>().SetSpeed(speed - 2);

            if (distanceLane > 1) {
                // move the ball backward by 2, over a period of 2 seconds, 
                StartCoroutine(MovePet(pet.GetComponent<Transform>(),
                           pet.GetComponent<Transform>().position,
                           new Vector3(startMarker.position.x - lerpDistance, startMarker.position.y,
                           startMarker.position.z), lerpTime));

            controlLocked = true;
            distanceLane -= 1;
            StartCoroutine(UnLockControl(lerpTime));    // unlock after 2 seconds,  
            }// end if


  
        }// end if




    }// end update

    //******************************************************************************************************************************

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            SceneManager.LoadScene("GameOver");
            mainCamera.GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 0);    // stops the camera if the ball hits an obstacle 
            pet.GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 0);        // stops player when hits obstacle
        } // end if

    } // end OnTriggerEnter


    //******************************************************************************************************************************

    // method to stop player after half second of horizontal movement. 
    IEnumerator StopSlide() {

        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = false;
    }// end stopSlide

    //******************************************************************************************************************************

    // method to lock the controls
    //waits desired amount of time then unlocks control
    IEnumerator UnLockControl(float timeToWait)
    {

        yield return new WaitForSeconds(timeToWait);
        controlLocked = false;

    }// end LockControl


    //******************************************************************************************************************************
    // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.

    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    } // end ExtendUnlockAndNotifyUserAction
    //******************************************************************************************************************************
    

    // this method moves the pet object smoothley between two Vector3 points.  Time here is the time the transition takes

    IEnumerator MovePet(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)

        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }//end while

    }//end MovePet
     //******************************************************************************************************************************

}// end MovOrb