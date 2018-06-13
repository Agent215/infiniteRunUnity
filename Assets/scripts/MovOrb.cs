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
 * Because this will be implemented in VR, the player will be the camera.
 * 
 * In order to move the pet in a realitic fashion a class called SphericalCpprdinates.cs is used to 
 * convert from Vector3 cartesion coordinates to polar coordinates. Then we can perform a radial function on the
 * coordinates to move the pet in circular or curvy path.
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

    //polar coordinates of objects
    public SphericalCoordinates petPolarCoord;
    public SphericalCoordinates playerPolarCoord;
    public SphericalCoordinates petPolarTarget;

    // use this to adjust the radius from the player to the pet
    public float radiusModifier;
    public float radius;

    //objects in game
    public GameObject pet;                
    public GameObject mainCamera;
    public GameObject gameControl;        

    //Locations in space
    public Vector3 petCartesianTarget;
    public Vector3 petPos;                   // Starting position of pet
    public Vector3 playerPos;               //player postition
    readonly float GROUND_LEVEL= .5f;       // level the pet should be at to touch the ground.  this should not change.
    
    //track horizontal lane position of pet
    public int laneNumber = 2;            //   Left= 1 , Middle=2 , Right =3

    // use to prevent rapid button mashing of controls. while false controls  will work.
    private bool controlLocked = false;  
   
    // use to track speed relitive to tunnel 
    private float speed;              

    // lerp variables to move pet smoothly based on speed of movement.
    public float lerpTime; 
    public float lerpDistance;
   
   

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
        lerpTime = 1.0F;
        lerpDistance = 3.0F;
        radiusModifier = 1.0F;

        //create new spericacl coordinates, (Vector3, radius min, radius max , min polar, max polar, min elevvation , max elevation)
        petPolarCoord = new SphericalCoordinates(petPos,1f,200f, 0f, (Mathf.PI * 2f), 0f , (Mathf.PI / 3f));
        playerPolarCoord = new SphericalCoordinates(playerPos, 1f, 200f, 0f, (Mathf.PI * 2f), 0f, (Mathf.PI / 3f));
        petPolarTarget = new SphericalCoordinates(petPos, 1f, 200f, 0f, (Mathf.PI * 2f), 0f, (Mathf.PI / 3f));


        //set spherical coordinates
        petPolarCoord = petPolarCoord.FromCartesian(petPos);
        playerPolarCoord = playerPolarCoord.FromCartesian(playerPos);

        radius = petPolarCoord.toCartesian.x;

        // debugging
        Debug.Log(playerPolarCoord.ToString() + "this is the players polar coordinates");
        Debug.Log(playerPolarCoord.toCartesian.ToString()+ "players cartesian coordinates");
        Debug.Log(petPolarCoord.ToString() + "this is the pets polar coordinates");
        Debug.Log(petPolarCoord.toCartesian.ToString() + "pets cartesian coordinates");



    }// end start

    //******************************************************************************************************************************
    // Update is called once per frame
    void Update()
    {
        //update player position
        playerPos = mainCamera.transform.position;
        petPos = pet.transform.position;
        playerPolarCoord = playerPolarCoord.FromCartesian(playerPos);
        petPolarCoord = petPolarCoord.FromCartesian(petPos);

       
        //update lane number
        laneNumber = gameControl.GetComponent<CamMov>().laneNumber;

        //update speed
        speed = gameControl.GetComponent<HallCam>().outputSpeed;

        //set the targets coordinates for the pet to be whatever the players is,
        petPolarTarget = playerPolarCoord;

        //update radius
        radius = petPolarCoord.radius;


        //set target for pet to move towards depending on various input.
        // we can change these later as neeeded. 
        petPolarTarget.SetRadius(radius);

        //if we are speeding up move pet closer
        if ((Input.GetKeyDown(speedUp)))
        {

            radius -= radiusModifier;
            petPolarTarget.SetRadius(radius);
            petPolarCoord.SetRadius(radius);

        }// end if


        //if we are slowing down move pet farther away
        if ( (Input.GetKeyDown(slowDown)))
        {

            radius += radiusModifier;
            petPolarTarget.SetRadius(radius);
            petPolarCoord.SetRadius(radius);

        }// end if

        //pets polar angle will be the same as the player
        petPolarTarget.SetPolarAngle(petPolarTarget.polar);

        // back to Vector3 coordinates to be used in lerp function
        petCartesianTarget = petPolarTarget.toCartesian;

        // y axis offset for ground level
        petCartesianTarget.y = GROUND_LEVEL;


        // debuging
        Debug.Log(playerPolarCoord.ToString() + "this is the players polar coordinates");
        Debug.Log(petPolarCoord.ToString() + "this is the pets polar coordinates");
        Debug.Log(petPolarTarget.ToString() + "this is the pets targets polar coordinates");
        Debug.Log(petCartesianTarget.ToString() + "this is the pets cartesian target coordinates");
        Debug.Log(playerPolarCoord.toCartesian.ToString() + "players cartesian coordinates");

        // move the pet to follow the player
        StartCoroutine
                    (MovePet(pet.GetComponent<Transform>(),
                     pet.GetComponent<Transform>().position,
                     petCartesianTarget, lerpTime));

    }// end update

    //******************************************************************************************************************************

    // method to lock the controls
    //waits desired amount of time then unlocks control
    IEnumerator UnLockControl(float timeToWait)
    {

        yield return new WaitForSeconds(timeToWait);
        controlLocked = false;

    }// end LockControl



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

        controlLocked = false;
    }//end MovePet
     //******************************************************************************************************************************

}// end MovOrb