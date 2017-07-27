using UnityEngine;
using System.Collections;

public class PressurePad : MonoBehaviour {


    private bool pressureOn = false;
    private GameObject pad;
    public GameObject child;


	// Use this for initialization
	void Start () {
        pad = this.gameObject;
        if (child == null)
        {
            child = pad.transform.GetChild(0).gameObject;
        }
        
    }
	
	// Update is called once per frame

	void Update () {
	    if(pressureOn)
        {
            child.SetActive(false);
        } else
        {
            child.SetActive(true);
        }
	}

    void OnCollisionEnter(Collision hit)
    {
        pressureOn = true;
    }


    void OnCollisionExit(Collision hit)
    {
        pressureOn = false;
    }
}
