using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {


    public float rotationSpeed = 60.0f; // degrees per second
    public Transform Tf;
    public Rigidbody rb;
    public GameObject gameControl;
    public float speed;

    void Start()
    {

        
        rb = GetComponent<Rigidbody>();
        gameControl = GameObject.Find("Game Control");
    }

    // Update is called once per frame
    void FixedUpdate () {

      
        // update speed
        speed = gameControl.GetComponent<HallCam>().outputSpeed;

        rb.transform.Rotate(Vector3.up, Space.World);
        //move objects towards player
         //rb.transform.Translate(-speed / 20, 0,0);
       
    }


    void OnTriggerEnter(Collider other)
    {

        // if coin hits bike destroy coin and add to score
        if (other.gameObject.name == "Hoverbike")
        {
            gameControl.GetComponent<GameControl>().AddScore();
            Destroy(this.gameObject);
        }

    }
}
