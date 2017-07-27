using UnityEngine;
using System.Collections;

public class GravityField : MonoBehaviour {

    public float gravity = 5.0f;
    private Vector3 originalGravity;
	// Use this for initialization
	void Start () {
        originalGravity = Physics.gravity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.name == "Player")
        {
            print("yes");
            Physics.gravity = new Vector3(0, -gravity, 0);
            Vector3 vel = hit.GetComponent<Rigidbody>().velocity;
            hit.GetComponent<Rigidbody>().velocity = new Vector3(vel.x, vel.y * 0.2f, vel.z);
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if(hit.gameObject.name == "Player")
        {
            Physics.gravity = originalGravity;
        }
    }
}
