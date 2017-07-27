using UnityEngine;
using System.Collections;

public class C2DestructPlatform : MonoBehaviour {

    public bool active = false;
    public bool startActive = false;
    public GameObject moveTowards;
    public float speed;
    public bool jumpForce;
    private bool playerTouched;
    private GameObject player;
    private Vector3 targetpos;
    private Rigidbody rb;
    private Vector3 dir;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        dir = (moveTowards.transform.position - transform.position).normalized;
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (active && playerTouched)
            transform.position = Vector3.MoveTowards(transform.position, moveTowards.transform.position, speed * Time.fixedDeltaTime);

        if(transform.position == moveTowards.transform.position)
        {
            rb.isKinematic = false;

            if(player.transform.parent == transform)
                player.transform.parent = null;
               
            rb.AddForce(dir * speed, ForceMode.Force);
            //player.GetComponent<Rigidbody>().AddForce(dir * 100, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name.Equals("Player"))
        {
            hit.transform.parent = transform;
            playerTouched = true;
        }
            
    }

    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.name.Equals("Player"))
        {
            if(jumpForce)
                player.GetComponent<Rigidbody>().AddForce(dir * 2000);
            hit.transform.parent = null;
        }
    }

    public void Reset()
    {
        if(active)
        {
            if (player.transform.parent == transform)
            {
                player.transform.parent = null;
            }
            active = false;
            rb.isKinematic = true;
            playerTouched = false;
            transform.position = startPos;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
