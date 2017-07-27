using UnityEngine;
using System.Collections;

public class SlidingFloor : MonoBehaviour {


    public float pushForce = 100;
    public bool move;
    private Rigidbody playerRb;
    private Vector3 dir;
    private Vector3 lastPos;

	// Use this for initialization
	void Start () {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
        dir = this.gameObject.transform.forward;
    }
	
	// Update is called once per frame

	void Update () {
        if (move)
        {
            playerRb.AddForce(dir * pushForce);
        }
        if(lastPos == playerRb.transform.position)
        {
            print("yes");
        }
        lastPos = playerRb.transform.position;
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            move = true;
        }
    }

    void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            move = true;
        }

    }


    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            move = false;
        }
    }
}
