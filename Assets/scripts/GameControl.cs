using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public Transform ground;   //locations of ground prefab
    GameObject player;  // object to hold player
    Vector3 playerPos;  // player position

	// Use this for initialization
	void Start () {
        
        player = GameObject.Find("player");
        playerPos = player.transform.position;
        Instantiate(ground,playerPos, ground.rotation);
	}
	
	// Update is called once per frame
	void Update () {
        playerPos = player.transform.position;
	}
}
