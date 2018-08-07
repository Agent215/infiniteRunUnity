/*GameControl.cs - Abraham Schultz- july 2018
 * 
 * A class to control the spawning of objects in the central game scene.
 *  
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public GameObject tempObject;
    public GameObject building;
    public GameObject Turret;
    public GameObject coin;
    public GameObject obstacle;
    public Vector3 spawnValues;
    public int coinCount;
    public int TurretCount;
    public int obstacleCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float ObstacleLaneNumber;
    public float BuildingLaneNumber;
    public float TurretLaneNumber;
    public float CoinLaneNumber;
    public float yRotation;
    public float xRotation;
    public float zRotation;
    public Scene currentScene;

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
        xRotation = 0.0f;
        zRotation = 0.0f;
        currentScene = SceneManager.GetActiveScene();

    } // end start

    //******************************************************************************************************************************

  
      // Update is called once per frame
    void Update () {

        //random seed number for object placement 
        randomPos = Random.value;
        randomSeed = Random.value;
        yRotation = 0;
        xRotation = 0;
        zRotation = 0;
        //check which scene we are in
        currentScene = SceneManager.GetActiveScene();

        // change obstacle and coins change location randomly between three lanes left middle and right 

        //middle lane
        if (randomPos > .33f && randomPos < (.66f))
            {

            BuildingLaneNumber = -11.0f;
            TurretLaneNumber = -5.0f;
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
            TurretLaneNumber = 5.0f;


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
            
            //check to see what scene we are in. if we are not in the main level stop corotines.  hardcoded for debugging
            if (currentScene.name != "hallway 1") { StopAllCoroutines(); }
        
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

                //spawn buildings
                Vector3 BuildingPosition = new Vector3(40.0f, 0, BuildingLaneNumber);
                Quaternion buildingRotation = Quaternion.identity;
               
                buildingRotation.eulerAngles = new Vector3(xRotation, yRotation, zRotation);
               tempObject = Instantiate(building, BuildingPosition, buildingRotation);
             
                //if (BuildingLaneNumber == 11.0f)
                //{
                //    tempObject.transform.rotation.SetEulerAngles(new Vector3(xRotation, yRotation, zRotation));
                //}

                //else if (BuildingLaneNumber == -11.0f)
                //{
                //    tempObject.transform.rotation.SetEulerAngles(new Vector3(xRotation, 180, zRotation));

                //}




                //spawn turrets
                Vector3 TurretPosition = new Vector3(50.0f, 0, TurretLaneNumber);
                Quaternion TurretRoation = Quaternion.identity;
                TurretRoation.eulerAngles = new Vector3(0, yRotation, 0);
                Instantiate(Turret, TurretPosition, TurretRoation);

                yield return new WaitForSeconds(spawnWait);
            }


            

            yield return new WaitForSeconds(waveWait);

        } // end while

    } // end SpawnObjects

    /*
    
   method to spawn various buildings pseudo randomly
   method should spawn buildings in forgreound, midground, and background ranges
   method should take in as argument the desired roation and lane ID number for placement also the gameobject repesenting the building

   IEnumerator SpawnBuildings (Quaternion rotation, int laneId,GameObject Building) {

        //algorithim to spawn a specific pattern
           return;
                                                                                      } // end SpawnBuildings 




   method to spawn various obstacles pseudo randomly
   method should spawn obstacles one of three possible lanes middle, left or right
   method should pawn obstacles in one of three possible height lanes low medium high
   method should take in as argument the desired roation and lane ID number for placement also the gameobject repesenting the obstacles

         IEnumerator SpawnObstacles (Quaternion rotation, int laneId, int heightLane ,GameObject obstacle) {
         //algorithim to spawn a specific pattern
           return;
                                                                                      } // end SpawnObstacles 

  method to spawn various collectiables pseudo randomly
   method should spawn collectable one of three possible lanes middle, left or right
   method should pawn collectables in one of three possible height lanes low medium high
   method should take in as argument the desired roation and lane ID number for placement also the gameobject repesenting the obstacles

         IEnumerator SpawnCollectabkes (Quaternion rotation, int laneId, int heightLane, GameObject collectable) {
         //algorithim to spawn a specific pattern
           return;
                                                                                      } // end SpawnCollectables 


    */

    //******************************************************************************************************************************

    //method to iterate score by 1
    public void AddScore() {
        score += 1;

    } // end AddScore

} // end GameControl
