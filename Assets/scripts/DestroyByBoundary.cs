/*DestroyByBoundary.cs- June 2018- Abraham Schultz
 * 
 *Destroys objects as they leave the play area
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
