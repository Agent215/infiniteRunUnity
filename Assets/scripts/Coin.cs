/*Coin.cs-Abraham Schultz- july 2018
 * 
 * A script to definre
 * 
 * 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


    public float rotationSpeed = 60.0f;  // degrees per second
    public Transform Tf;                 //transform of coin
    public Rigidbody rb;                 //rigidbody of coin
    public GameObject gameControl;      // to get data from gamecontrol object
    public float speed;                 
  //******************************************************************************************************************************
    void Start()
    {

        //get rigid body of object script is attached to
        rb = GetComponent<Rigidbody>();
        gameControl = GameObject.Find("Game Control");

    }// end start
  //******************************************************************************************************************************
    // FixedUpdate is called once per frame
    void FixedUpdate () {

      
        // update speed
        speed = gameControl.GetComponent<HallCam>().outputSpeed;
        //rotate coind around y axis of world
        rb.transform.Rotate(Vector3.up, Space.World);
      
       
    } // end fixed update
 //******************************************************************************************************************************

    void OnTriggerEnter(Collider other)
    {

        // if coin hits bike destroy coin and add to score
        if (other.gameObject.name == "Hoverbike")
        {
            gameControl.GetComponent<GameControl>().AddScore();
            Destroy(this.gameObject);
        } // end if

    } // end OnTriggerEbter
 //******************************************************************************************************************************
} // end Coin.cs
