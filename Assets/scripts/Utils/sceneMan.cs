
/* SceneMan.cs - Abraham Schultz - july2018- InflectionPoints Arts and Sciences
 * 
 * A class to switch between scenes in game. 
 * 
 */

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class sceneMan : MonoBehaviour
{

    public void LoadMain() {
        StopAllCoroutines();
        //SceneManager.LoadScene("hallway 1");
        StartCoroutine(LoadMainLevel());
    }

    public void LoadStart()
    {
        StopAllCoroutines();
        //SceneManager.LoadScene("StartMenu");
        StartCoroutine(LoadStartMenu());
    }



    IEnumerator LoadMainLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("hallway 1");

       

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    } // end LoadMainLevel

     IEnumerator LoadStartMenu()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StartMenu");
        


        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
    } // end LoadStartMenu

    public void Quit()

    {


        Application.Quit();
    } // end Quit


} // end SceneMan
