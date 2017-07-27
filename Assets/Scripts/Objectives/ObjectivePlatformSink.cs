using UnityEngine;
using System.Collections;

public class ObjectivePlatformSink : MonoBehaviour {

    /*      
     *     Assign the movement speed and the distance it has travel
     */

    public GameObject attachedOb;
    public float moveSpeed = 1;
    public float goalDistance = 500;
    private float currentDistance = 0;
    private bool moveAway;
    public bool goal = false;
 
	// Update is called once per frame
	void FixedUpdate () {
		
	//If the goal is met

	if (moveAway)       // Move to designated position
		{
			if(currentDistance >= 400) {
				goal = true;
			} else {
				currentDistance += moveSpeed;
		transform.Translate(Vector3.down * moveSpeed * Time.fixedDeltaTime);
			}
	    }

		if(goal)
	{
        }

  
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "Player") // when the player hits the obstacle the platform begins moving
        {
            moveAway = true;
            hit.transform.parent = transform;
        }
    }
    
    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.name == "Player") // when the player hits the obstacle the platform begins moving
        {
			hit.transform.parent = null;
			moveAway = false;
		}
	}


}
