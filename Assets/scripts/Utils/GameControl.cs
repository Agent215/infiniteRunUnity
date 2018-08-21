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

    private GameObject gameControl;
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

        gameControl = GameObject.Find("Game Control");
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
    void  FixedUpdate () {

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

                //spawn coins
                gameControl.GetComponent<SpawnObject>().SpawnObjects(CoinLaneNumber, coin, spawnValues.x, spawnValues.y, CoinLaneNumber);
                //spawn obstacles
                gameControl.GetComponent<SpawnObject>().SpawnObjects(ObstacleLaneNumber, obstacle, spawnValues.x, spawnValues.y, ObstacleLaneNumber);

                //spawn buildings
                gameControl.GetComponent<SpawnObject>().SpawnObjects(BuildingLaneNumber, building, 40, 0, BuildingLaneNumber);
                //spawn turrets
                gameControl.GetComponent<SpawnObject>().SpawnObjects(TurretLaneNumber, Turret, 50, 0, TurretLaneNumber);
               

                yield return new WaitForSeconds(spawnWait);
            }



            yield return new WaitForSeconds(waveWait);

        } // end while

    } // end SpawnObjects

  

    //******************************************************************************************************************************

    //method to iterate score by 1
    public void AddScore() {
        score += 1;

    } // end AddScore

} // end GameControl
