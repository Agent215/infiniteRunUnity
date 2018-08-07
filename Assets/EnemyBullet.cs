using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour {

    public GameObject explosionPreFab;

    // Update is called once per frame
    void Update()
    {

        //destroys bullets after 5 seconds
        Destroy(this.gameObject, 5);
    }

    void OnTriggerEnter(Collider col)
    {
        

        
        if (col.gameObject.tag == "Player")
        {

            Debug.Log("player has been shot");
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;


        }

    }// end OnTriggerEnter
}
