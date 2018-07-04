/*DestroyByBoundary.cs- June 2018- Abraham Schultz
 * 
 *Destroys objects as they leave the play area
 * script is attached to the collider of a prefab cube mesh object within the unity inspector.
 * later we will change this so the script does not need to be attached in the inspecter.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    } // end OnTriggerExit

} // end DestroyByBoundary 
