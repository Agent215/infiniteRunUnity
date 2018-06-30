using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject building;
    public GameObject coin;
    public GameObject obstacle;
    public Vector3 spawnValues;
    public int coinCount;
    public int obstacleCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float ObstacleLaneNumber;
    public float BuildingLaneNumber;
    public float CoinLaneNumber;
    public float yRotation;

    public int score;

    // random number for positioning objects
    public float randomPos;
    public float randomSeed;



    // Use this for initialization
    void Start () {
        score = 0;
        StartCoroutine(SpawnObjects());
        randomPos = Random.value;
        yRotation = 0.0F;

    } // end start

    //******************************************************************************************************************************

      // Update is called once per frame
    void Update () {

        //random seed number for object placement 
        randomPos = Random.value;
        randomSeed = Random.value;

       

        // change obstacle and coins change location randomly between three lanes left middle and right 
        
        //middle lane
            if (randomPos > .33f && randomPos < (.66f))
            {

            BuildingLaneNumber = -11.0f;
            ObstacleLaneNumber = 0.0f;

            if (randomSeed <= .2f)
                CoinLaneNumber = -2.0f;

            if (randomSeed >= .8f)
                CoinLaneNumber = 2.0f;


        } // end if

        //right lane
            if (randomPos > .66f)
            {

            BuildingLaneNumber = 11.0f;
            ObstacleLaneNumber = -2.0f;



            if (randomSeed <= .2f)
                CoinLaneNumber = 0.0f;

            if (randomSeed >= .8f)
                CoinLaneNumber = 2.0f;

        } // end if

       // left lane 
            if (randomPos < .33f)
            {

            ObstacleLaneNumber = 2.0f;


            if (randomSeed <= .2f)
                CoinLaneNumber = 0.0f;

            if (randomSeed >= .8f)
                CoinLaneNumber = -2.0f;

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
                //spawn obstacles
                Vector3 ObstaclePosition = new Vector3(spawnValues.x, spawnValues.y, ObstacleLaneNumber);
                Quaternion ObstacleRotation = Quaternion.identity;
                Instantiate(obstacle, ObstaclePosition, ObstacleRotation);


                // spawn coins
                Vector3 CoinPosition = new Vector3(spawnValues.x, spawnValues.y, CoinLaneNumber);
                Quaternion CoinRotation = Quaternion.identity;
                Instantiate(coin, CoinPosition, CoinRotation);

               
                Vector3 BuildingPosition = new Vector3(40.0f, 0, BuildingLaneNumber);
                Quaternion buildingRotation = Quaternion.identity;
                buildingRotation.eulerAngles = new Vector3(0, yRotation, 0);
                Instantiate(building, BuildingPosition, buildingRotation);
           

               

                yield return new WaitForSeconds(spawnWait);
            }


            

            yield return new WaitForSeconds(waveWait);

        } // end while

    } // end SpawnObjects

    //******************************************************************************************************************************

    public void AddScore() {
        score += 1;

    }
} // end GameControl
