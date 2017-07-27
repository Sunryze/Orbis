using UnityEngine;
using System.Collections;

public class LaserWall : MonoBehaviour {

    public bool blockOrb;
    private GameObject orb;

	// Use this for initialization
	void Start () {
        orb = GameObject.FindGameObjectWithTag("Orb");
        if(!blockOrb)
        {
            Physics.IgnoreCollision(orb.GetComponent<Collider>(), GetComponent<Collider>());
        }
        
	}
	
}
