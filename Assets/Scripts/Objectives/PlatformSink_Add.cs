using UnityEngine;
using System.Collections;

// Use this script with PlatformSink if you want to enable/disable more objects from one pillar 

public class PlatformSink_Add : MonoBehaviour {

    public GameObject targetOb;
    private PlatformSink thisScript;
    private PressurePadTarget targetScript;

	// Use this for initialization
	void Start () {
        thisScript = this.gameObject.GetComponent<PlatformSink>();
        targetScript = targetOb.GetComponent<PressurePadTarget>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(thisScript.goal)                             //When the main script is done we increment the press counter of target object and disable this so it doesn't add more
        {
            targetScript.pressCounter++;
            this.enabled = false;
        }
	}
}
