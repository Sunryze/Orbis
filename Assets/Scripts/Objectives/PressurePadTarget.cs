using UnityEngine;
using System.Collections;

/*      Attach this script to the object that will show/hide when pressure pad is collided with
 * 
 */

public class PressurePadTarget : MonoBehaviour {

    public bool showInitial = true;            // Set to true if you want it showing to begin with, pressing button will disable it. False to have it hide initially, show when button pressed
    public int requiredPresses;         // Set the amount of children it has (how many presses to enable)
    public int pressCounter = 0;         // Don't change this, number will increase when other scripts increment it
    private Renderer rend;
    private BoxCollider col;

    // Is the player blocking the space this barrier wants to appear in.
    private bool playerBlocked;
	
    // Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<Renderer>();        // We'll hide the renderer and boxcollider instead of disabling the whole object, otherwise we can't re-enable it.
        col = gameObject.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (showInitial)
        {
            if (pressCounter >= requiredPresses)
            {
                rend.enabled = false;
                col.enabled = false;
                // success
            }
            else
            {
                if(!playerBlocked)
                {
                    rend.enabled = true;
                    col.enabled = true;
                    // fail
                }
            }
        }
        else
        {
            if (pressCounter >= requiredPresses)
            {
                rend.enabled = true;
                col.enabled = true;
                // success
            }
            else
            {
                rend.enabled = false;
                col.enabled = false;
                // fail
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.name.Equals("Player") && !rend.enabled)
        {
            GetComponent<TempDeath>().active = false;
            playerBlocked = true;
        }        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name.Equals("Player") && playerBlocked)
        {
            playerBlocked = false;
            GetComponent<TempDeath>().active = true;
        }
    }
}
