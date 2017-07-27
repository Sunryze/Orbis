using UnityEngine;
using System.Collections;

public class OrbProperties : MonoBehaviour {
    public GameObject player;
    private LaunchOrb orbScript;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("MainCamera");
		transform.parent = player.transform;
        Physics.IgnoreCollision(player.transform.parent.GetComponent<Collider>(), GetComponent<Collider>());
        orbScript = player.GetComponent<LaunchOrb>();
	}

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "LaserWall")  
        {
            orbScript.OrbToPlayer();
        }
    }
}
