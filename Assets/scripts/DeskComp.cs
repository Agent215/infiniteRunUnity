/* DeskComp.cs -Abraham Schultz - July 2018
 * 
 * Script to control interaction with computer object in main menu scene
 *  
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeskComp : MonoBehaviour {



    void OnMouseEnter()
    {

        Debug.Log("mouse over computer screen");
    } // end OnMouseEnter

    void OnMouseDown()
    {

        Debug.Log("Computer Screen Clicked");
        // if computer is clicked change scene to hall way 1


        SceneManager.LoadScene("hallway 1");
    } // end OnMouseDown

} // end DeskComp
