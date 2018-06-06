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
    public float obs_posX;
    public GameObject Tunnel1;
    public GameObject Tunnel2;
    public GameObject Tunnel3;
    public GameObject Everything;
    public Transform Obstacle;
    public GameObject Obstacle_1;
    public Vector3 EveryPos;
    private Vector3 SceneRotation;

    //Camera
    Camera mainCam;
    private Vector3 camPos = new Vector3(-105f, 4f, 0);
    private Vector3 camRotation;

    //velocity accuracy
    public float distance;
    public float velocity;
    public float tempo;

    // lanes to position objects randomly
    public float leftLane = -2;
    public float middleLane = 0;
    public float rightLane = 2;

    // speed 
    [SerializeField]
    public float outputSpeed;

    // random number for positioning objects
    public float randomPos;


    // Use this for initialization
    void Start () {

        Instantiate(Obstacle, new Vector3(-20f, .5f, 0), Obstacle.rotation);

        //set speed harcoded for debugging
        outputSpeed = 3;

        Tunnel1 = GameObject.Find("Tunnel 1");
        Tunnel2 = GameObject.Find("Tunnel 2");
        Tunnel3 = GameObject.Find("Tunnel 3");
        Everything = GameObject.Find("Hallway");
        mainCam = Camera.main;
        

    } // end Start
	
	// Update is called once per frame
	void FixedUpdate () {



        Obstacle_1 = GameObject.Find("obstacle 1(Clone)");
      
        //move obstacle 1
        Obstacle_1.transform.Translate(-outputSpeed / 20, 0, 0);

        mainCam.transform.position = camPos;
        // Get & Set Planes Positions //
        pos_x1 = Tunnel1.transform.position.x;
        pos_x2 = Tunnel2.transform.position.x;
        pos_x3 = Tunnel3.transform.position.x;

        // set position of obstacle
        obs_posX = Obstacle_1.transform.position.x;
        Everything.transform.position = EveryPos;


        //move tunnel pieces 
        Tunnel1.transform.Translate(-outputSpeed / 20, 0, 0);
        Tunnel2.transform.Translate(-outputSpeed / 20, 0, 0);
        Tunnel3.transform.Translate(-outputSpeed / 20, 0, 0);

        //check tunnel locations and move them.
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

        // change obstacle location randomly between three lanes lefft middle and right after reset
        if (obs_posX < -110)
        {
            //middle lane
            randomPos = Random.value;
            if (randomPos > .33f && randomPos < ( .66f)) {

                Obstacle_1.transform.position = new Vector3(pos_x2 + 110f, .5f, middleLane);
            } // end if

           //right lane
           if(randomPos > .66f)
            {
                Obstacle_1.transform.position = new Vector3(pos_x2 + 110f, .5f, rightLane);
            } // end if

           // left lane 
           if(randomPos < .33f)
            {

                Obstacle_1.transform.position = new Vector3(pos_x2 + 110f, .5f, leftLane);
            } // end if 

        }// end if

       

    }// end FixedUpdate

    //setter 
    public void SetSpeed(float speedIn) {
        outputSpeed = speedIn;
    }// end setSpeed

    //Getter
    public float GetSpeed() {
        return outputSpeed;
    }// end GetSpeed

} //end HallCam
