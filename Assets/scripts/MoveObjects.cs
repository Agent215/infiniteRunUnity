/*MoveObjects.cs -Abraham Schultz -July 2018
 * 
 * Script to make objects move at the same speed towards player.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to move objects towards player 

public class MoveObjects : MonoBehaviour {

    public float speed;
    public Rigidbody rb;
    private GameObject gameControl;
    public float speedDirection;
    public float startingLaneBuilding;
    public float startingLaneTurret;

//******************************************************************************************************************************
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        gameControl = GameObject.Find("Game Control");

        startingLaneBuilding = gameControl.GetComponent<GameControl>().BuildingLaneNumber;

        startingLaneTurret = gameControl.GetComponent<GameControl>().TurretLaneNumber;

        if (this.gameObject.tag.Equals("Building"))
        {
            speedDirection = SetDirection(startingLaneBuilding);

        }
        else if (this.gameObject.tag.Equals("Enemy"))
        {
            speedDirection = SetDirection(startingLaneTurret);
        }

        else if (this.gameObject.tag.Equals("obstacle"))
        {

            speedDirection = speed;
        }
        else if (this.gameObject.tag.Equals("Coin"))
        {

            speedDirection = speed;

        }
        else if (this.gameObject.tag.Equals("effect")) {

            speedDirection = speed;

        }
       
        //speedDirection = SetDirection(gameControl.GetComponent<GameControl>().BuildingLaneNumber);
    } // end start

 //******************************************************************************************************************************	
      // Update is called once per frame
    void FixedUpdate () {
        


        // update speed, but only get the absulute value
        speed =  gameControl.GetComponent<HallCam>().outputSpeed;

        if (this.gameObject.tag.Equals("Building"))
        {
            speedDirection = SetDirection(startingLaneBuilding);

        }
        else if (this.gameObject.tag.Equals("Enemy"))
        {
            speedDirection = SetDirection(startingLaneTurret);
        }

        if (this.gameObject.tag.Equals("obstacle"))
        {

            speedDirection = speed;
        }
        else if (this.gameObject.tag.Equals("Coin"))
        {

            speedDirection = speed;

        }
        else if (this.gameObject.tag.Equals("effect"))
        {

            speedDirection = speed;

        }
        //move objects towards player in the negatvie x direction of the object to be moved
        rb.transform.Translate(-speedDirection / 20, 0, 0);
    } // end FixedUpdate

    //******************************************************************************************************************************


    // method to setDirection of gameObject movement. this direction should always be towards the camera/player
    // because 
    public float SetDirection(float laneNumber) {

        float speedIn = speed;
        

        if (laneNumber < 0) {

            speedIn *= -1;

        } // end if

        return speedIn;
    }// end SetDirection

} // end MoveObjects.cs
