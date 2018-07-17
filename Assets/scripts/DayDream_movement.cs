using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayDream_movement : MonoBehaviour {

    private Vector2 CurrentTouch;
    public GameObject Controller;

	// Use this for initialization
	void Start () {

     
	}
	
	// Update is called once per frame
	void Update () {

        CurrentTouch = GvrControllerInput.TouchPos;


	}
}
