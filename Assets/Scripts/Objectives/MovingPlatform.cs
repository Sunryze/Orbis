using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    /*      Designate a location x,y,z away from the original platform's location
     *      If the player touches it, it will begin moving 
     *      Once the player moves away if will return to its original position
     *      The platform will continue to move until the player has left
     *      
     *      
     *     
     */
    
    public float xMove = 0;
    public float yMove = 2;
    public float zMove = 0;
    public float moveSpeed = 2;
    public float range = 15;  
    private GameObject platform;
    private bool moveAway;
    private bool moveBack;
    private Vector3 startPos;

    // Use this for initialization
    void Start () {
        platform = this.gameObject;
        startPos = platform.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (moveAway)       // Move to designated position
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, (startPos + new Vector3(xMove, yMove, zMove)), moveSpeed * Time.fixedDeltaTime);
        GameObject player = GameObject.Find("Player");
        float distance = Vector3.Distance(platform.transform.position, player.transform.position);
        if (distance >= range && moveAway)   // Once the player leaves the vicinity of the platform, it moves back to its original position
        {
            moveBack = true;
            moveAway = false;
        }

        if (moveBack && platform.transform.position != startPos)        // Move back to original position
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, startPos, moveSpeed * Time.fixedDeltaTime);
        else
            moveBack = false;
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "Player") // when the player hits the obstacle the platform begins moving
        {
            moveBack = false;
            moveAway = true;
            hit.transform.parent = platform.transform;
        }
    }
    
    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.name == "Player") // when the player hits the obstacle the platform begins moving
            hit.transform.parent = null;
    }
}
