/*ComputerDisplay.cs -Abraham Schultz- July 2018
 * 
 * A script to display UI elements in main menu screen of infinte runner game
 * 
 * 
 * 
 * */

namespace GoogleVR.HelloVR
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    [RequireComponent(typeof(Collider))]

    public class ComputerDisplay : MonoBehaviour
    {

        public string displayString;
        public Text myText;
        public float fadeTime;
        public bool displayInfo;

        public Material LookingAtComp;     //material to display when looking at computer
        public Material NotLookingAtComp;  // material to display when not looking at computer

        private Renderer myRenderer;


        // Use this for initialization
        void Start()
        {
            myText = GameObject.Find("Computer Text").GetComponent<Text>();
            myText.color = Color.clear;
            GetComponent<Renderer>().material = NotLookingAtComp;
            myRenderer = GetComponent<Renderer>();
            SetGazedAt(false);
        } // end start 


        // Update is called once per frame
        void Update()
        {
            FadeText();

        } // end update 

//#if (UNITY_EDITOR || UNITY_STANDALONE_WIN)
//        // when running on editor or windows

//        //display text when cursor is over object
//        private void OnMouseOver()
//        {
//            displayInfo = true;
//            GetComponent<Renderer>().material = LookingAtComp;
//        } // end OnMouseOver

//        // hide text when cursor is not on object
//        private void OnMouseExit()
//        {
//            displayInfo = false;
//            GetComponent<Renderer>().material = NotLookingAtComp;
//        } // end onMouseExit

//#endif


        public void SetGazedAt(bool gazedAt)
        {
            if (NotLookingAtComp != null && LookingAtComp != null)
            {
                myRenderer.material = gazedAt ? LookingAtComp : NotLookingAtComp;
                return;
            }
        } // end SetGazedAt

#if UNITY_ANDROID
        //for Vr on Android

        public void OnPointerOver() { displayInfo = true; GetComponent<Renderer>().material = LookingAtComp; Debug.Log("pointer over computer screen"); } // end OnPointerOver

        public void OnPointerExit() { displayInfo = false; GetComponent<Renderer>().material = NotLookingAtComp; Debug.Log("Pointer Not over computer screen"); } // end OnPointerExit

        public void OnPointerClick() { StopAllCoroutines(); SceneManager.LoadScene("hallway 1"); } // end OnPointerClick


#endif



        // method to fade text in and out of UI
        void FadeText()
        {

            if (displayInfo)
            {
                myText.text = displayString;
                myText.color = Color.Lerp(myText.color, Color.black, fadeTime * Time.deltaTime);

            } // end if
            else
            {

                myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
            }
        } // end FadeText




        public void Recenter()
        {
#if !UNITY_EDITOR
      GvrCardboardHelpers.Recenter();
#else
            if (GvrEditorEmulator.Instance != null)
            {
                GvrEditorEmulator.Instance.Recenter();
            }
#endif  // !UNITY_EDITOR
        }

        public void ChangeScene()
        {

            SceneManager.LoadScene("hallway 1");

        }

    }// end ComputerDisplay
}
