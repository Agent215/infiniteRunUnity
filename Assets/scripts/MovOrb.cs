/* MovOrb.cs
 * Abraham Schultz
 * 
 * Last edited 06/13/2018
 * 
 * 
 * 
 * This is a script to move the players pet object in an endless run down a hallway
 * Input for movment is read in from the keyboard.
 * 
 * the pet is a simple sphere prefab for now. this will be replaced with an animal or character model.
 * 
 * The pet should follow the general direction of the player.
 * as the player speeds up the pet gets closer.
 * as the player slows down the pet gets farther away.
 * Because this will be implemented in VR, the player will be the camera.
 * 
 * 
 * 
 */

using System.Collections;
using UnityEngine;

public class MovOrb : MonoBehaviour {

    //movements and controls
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode speedUp;
    public KeyCode slowDown;

    // use this to adjust the distance from the player to the pet
    public float DistanceModifier;
   
    //objects in game
    public GameObject pet;                
    public GameObject mainCamera;
    public GameObject gameControl;
    public Transform petTransform;

    //Locations in space
    public Vector3 petCartesianTarget;
    public Vector3 petPos;                   // Starting position of pet
    public Vector3 playerPos;               //player postition
    readonly float FLIGHT_LEVEL= 2.0f;       // level the pet should be at to touch the ground.  this should not change.
    
    //track horizontal lane position of pet
    public int laneNumber = 2;            //   Left= 1 , Middle=2 , Right =3
   
    // use to track speed relitive to tunnel 
    private float speed;

    private float TouchY;

    // lerp variables to move pet smoothly based on speed of movement.
    public float lerpTime; 
    private float startTime;
    private float journeyLength;
    float distCovered;
    float fracJourney;

    //******************************************************************************************************************************
    // Use this for initialization
    void Start()
    {
        //get game objects
        gameControl = GameObject.Find("Game Control");
        mainCamera = GameObject.Find("Main Camera");
        pet = GameObject.Find("Pet");

        //set variables
        petPos = pet.transform.position;
        playerPos = mainCamera.transform.position;
        lerpTime = 0;
        DistanceModifier = 10.0F;
        petTransform = pet.transform;
        startTime = Time.time;
        journeyLength = .0F;



    }// end start

    //******************************************************************************************************************************
    // Update is called once per frame
    void  FixedUpdate()
    {

        TouchY = GvrControllerInput.TouchPos.y;

        //update time
        lerpTime = Time.deltaTime;

        //update player position
        playerPos = mainCamera.transform.position;
        petPos = pet.transform.position;
     
      
        //update lane number
        laneNumber = gameControl.GetComponent<CamMov>().laneNumber;

        //update speed
        speed = gameControl.GetComponent<HallCam>().outputSpeed;

        //set the targets coordinates for the pet to be whatever the players is,
        petCartesianTarget = playerPos;

        //debugging
        Debug.Log(petPos.x + "this is the pets location in x axis");

        //if we are speeding up move pet closer to player. but stop at player, harcoded for debugging
        if (GvrControllerInput.IsTouching && !(speed > 10) && (TouchY < .3f) && (DistanceModifier > 4.5))
            DistanceModifier -= .030f;

        //if we are slowing down move pet farther away but stop after distacne is to far ,harcoded for debugging
        if (GvrControllerInput.IsTouching && !(speed < 1) && (TouchY > .7f) && (DistanceModifier < 30))
            DistanceModifier += .030f;


        // set target
        petCartesianTarget.Set(playerPos.x + DistanceModifier, FLIGHT_LEVEL, playerPos.z);

        //get distance between current position and target vector
        journeyLength = Vector3.Distance(petPos, petCartesianTarget);

        // time since last frame
        distCovered = Time.deltaTime ;
        fracJourney = distCovered / journeyLength;

        //linear interpolation between pet current location and pet new location
        petTransform.position = Vector3.Lerp(petPos, petCartesianTarget, fracJourney);

    }// end FixedUpdate

    //*****************************************************************************************************************************************
   

}// end MovOrb