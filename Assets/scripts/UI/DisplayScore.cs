using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    Text txt;
    private int currentscore = 0;
    public GameObject gameControl;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Score : " + currentscore;
        gameControl = GameObject.Find("Game Control");
    }

    // Update is called once per frame
    void Update()
    {

        currentscore = gameControl.GetComponent<GameControl>().score;
        txt.text = "Score : " + currentscore;
        currentscore = PlayerPrefs.GetInt("TOTALSCORE");
        PlayerPrefs.SetInt("SHOWSTARTSCORE", currentscore);
    }
}
