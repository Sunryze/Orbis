using UnityEngine;
using System.Collections;

public class AutoMovePlatform : MonoBehaviour {


    /*      Designate a x/y/z direction and the platform will move towards it. 
     *      The platform will move automatically. After a set amount of seconds it will stop
     *      Once it reaches that point, it will return back to original position
     *      
     *      
     *      
     */


    public float xMove = 0;
    public float yMove = 0;
    public float zMove = 0;
    public float moveSpeed = 2;
    public float range = 15;
    private GameObject platform;
    private bool moveAway;
    private Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        platform = this.gameObject;
        startPos = platform.transform.position;
        moveAway = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = startPos + new Vector3(xMove, yMove, zMove);
        if (moveAway)   // Move to designated position
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, (targetPos), moveSpeed * Time.fixedDeltaTime);
    
        if (platform.transform.position == targetPos)   // Once the time reaches the set time, it moves back to its original position
            moveAway = false;

        if (!moveAway && platform.transform.position != startPos)        // Move back to original position
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, startPos, moveSpeed * Time.fixedDeltaTime);
        else
            moveAway = true;
    }


    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "Player") // when the player hits the obstacle the platform begins moving
        {
            hit.transform.parent = platform.transform;

        }
    }


    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.name == "Player") // when the player hits the obstacle the platform begins moving
            hit.transform.parent = null;
    }

}
