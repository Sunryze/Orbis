using UnityEngine;
using System.Collections;

/**
 * A pathing platform moves from PathingNode to PathingNode,
 * until it reaches the last node in its array, at which point it is moved back to its start.
 * */

public class PathingPlatform : MonoBehaviour {

    public GameObject initNode;
    public float speed;

    private Vector3 dir = new Vector3(0,0,0);
    private Vector3 startPos;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        // Set intial node to second item in array.
        MoveTowardsNode(initNode);
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(dir * Time.deltaTime * speed);
    }

    void FixedUpdate()
    {

    }

    // When platform node is hit
    public void OnNodeHit(GameObject node)
    {
        if(node.GetComponent<PlatformNode>().isEnd)
        {
            transform.position = node.GetComponent<PlatformNode>().nextNode.transform.position;
            return;
        }
        MoveTowardsNode(node.GetComponent<PlatformNode>().nextNode);
    }

    // Get direction from current position and position of passed node.
    void MoveTowardsNode(GameObject node)
    {
        dir = (node.transform.position - transform.position).normalized;
    }

    // Instantly set position to target node.
    void JumpToNode(GameObject node)
    {
        transform.position = node.transform.position;
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "Player")
            hit.transform.parent = transform;
    }

    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.name == "Player")
            hit.transform.parent = null;
    }

    public void Reset()
    {
        transform.position = startPos;
        MoveTowardsNode(initNode);
    }
}
