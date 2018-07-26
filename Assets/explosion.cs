using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {


    void Update()
    {

        //destroys bullets after 5 seconds
        Destroy(this.gameObject, 5);
    }

}
