
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
#if UNITY_ANDROID
    public void LoadMainLevel() {

        SceneManager.LoadScene("hallway 1");

    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit()

    {

      
        Application.Quit();
    }

#endif
}
