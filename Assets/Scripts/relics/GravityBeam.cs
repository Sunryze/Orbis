using UnityEngine;
using System.Collections;

public class GravityBeam : MonoBehaviour {

    public float speed = 1;
    private GameObject beam;
    private GameObject player;
    private bool active;
    private bool colliding;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        beam = this.gameObject;
        rb = player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(active)
        {
            colliding = true;
            active = false;
            rb.useGravity = false;
        }
        else
        {
            colliding = false;
            rb.useGravity = true;
        }
        if(colliding)
        {
            if (!CheckAtCentre())
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(beam.transform.position.x, beam.transform.position.y, player.transform.position.z - 10), speed * Time.fixedDeltaTime);
            }
            else
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10) + beam.transform.eulerAngles, speed * Time.fixedDeltaTime);
                //rb.MovePosition(beam.transform.position + beam.transform.forward * Time.fixedDeltaTime);
            
        }

	}

    void OnTriggerStay(Collider hit)
    {
        if(hit.gameObject == player)
        {
            active = true;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private bool CheckAtCentre()
    {
        if (player.transform.position.y == transform.position.y && player.transform.position.z == transform.position.z)
            return true;
        else
            return false;
    }
}
