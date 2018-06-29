using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to move objects towards player 

public class MoveObjects : MonoBehaviour {

    public float speed;
    public Rigidbody rb;
    private GameObject gameControl;

    // Use this for initialization
    void Start () {

       
        rb = GetComponent<Rigidbody>();
        gameControl = GameObject.Find("Game Control");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        // update speed
        speed = gameControl.GetComponent<HallCam>().outputSpeed;
        //move objects towards player
        rb.transform.Translate(-speed / 20, 0, 0);
    }
}
