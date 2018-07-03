/*ComputerDisplay.cs -Abraham Schultz- July 2018
 * 
 * A script to display UI elements in main menu screen of infinte runner game
 * 
 * 
 * 
 * */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerDisplay : MonoBehaviour {

    public string displayString;
    public Text myText;
    public float fadeTime;
    public bool displayInfo;
   


	// Use this for initialization
	void Start () {
        myText = GameObject.Find("Computer Text").GetComponent<Text>();
        myText.color = Color.clear;
	} // end start 
	
	// Update is called once per frame
	void Update () {
        FadeText();

    } // end update 

    //display text when cursor is over object
    private void OnMouseOver()
    {
        displayInfo = true;
    } // end OnMouseOver

    // hide text when cursor is not on object
    private void OnMouseExit()
    {
        displayInfo = false;
    } // end onMouseExit

    // method to fade text in and out of UI
    void FadeText() {

        if (displayInfo)
        {
            myText.text = displayString;
            myText.color = Color.Lerp(myText.color, Color.black, fadeTime * Time.deltaTime);

        } // end if
        else {

            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    } // end FadeText

}// end ComputerDisplay
