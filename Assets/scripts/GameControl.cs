using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject obstacle;
    public Vector3 spawnValues;
    public int obstacleCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float laneNumber;

    // random number for positioning objects
    public float randomPos;



    // Use this for initialization
    void Start () {

        StartCoroutine(SpawnObjects());
        randomPos = Random.value;

    } // end start

    //******************************************************************************************************************************

      // Update is called once per frame
    void Update () {

        //random seed number for object placement 
        randomPos = Random.value;


        // change obstacle location randomly between three lanes left middle and right 
        
        //middle lane
            if (randomPos > .33f && randomPos < (.66f))
            {
        
            laneNumber = 0.0f;
            
            } // end if

        //right lane
            if (randomPos > .66f)
            {
            laneNumber = -2.0f;
            } // end if

       // left lane 
            if (randomPos < .33f)
            {
        
            laneNumber = 2.0f;
            } // end if 


    } // end update

   //******************************************************************************************************************************

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < obstacleCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, laneNumber);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(obstacle, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        } // end while
    } // end SpawnObjects

 //******************************************************************************************************************************
} // end GameControl
