/*SpawnObjects.cs
 * 
 * class to hold public method to spawn objects
 * 
 * this method will be called from the gamecontrol script for each level to procedurally generate the levels
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    GameObject tempObject;
    float xRotation = 0;
    float yRotation = 0;
    float zRotation = 0;


    //general method to spawn game objects for procedural level generation
    public  void SpawnObjects(float obejctLaneNumber, GameObject Object,float xPos,float yPos, float zPos) {


        Vector3 ObjectPosition = new Vector3(xPos, yPos, zPos);
        Quaternion ObjectRotation = Quaternion.identity;

        // if left of center lane
        if (obejctLaneNumber > 0)
        {


            ObjectRotation.eulerAngles = new Vector3(xRotation, yRotation, zRotation);
        }
        // else if right of center
        else if (obejctLaneNumber < 0)
        {

          
            ObjectRotation.eulerAngles = new Vector3(xRotation, 180, zRotation);
        }



        tempObject = Instantiate(Object, ObjectPosition, ObjectRotation);

    }

}
