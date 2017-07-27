using UnityEngine;
using System.Collections;

public class MovingBarrier : MonoBehaviour {

    public float xMove = 0;
    public float yMove = 0;
    public float zMove = 0;
    public float moveSpeed = 2;
    private GameObject barrier;
    private bool moveAway;
    private Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        barrier = this.gameObject;
        startPos = barrier.transform.position;
        moveAway = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = startPos + new Vector3(xMove, yMove, zMove);
        if (moveAway)
        {   // Move to designated position
            barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, targetPos, moveSpeed * Time.fixedDeltaTime);
        }
    
        if (this.gameObject.transform.position == targetPos)  
            moveAway = false;

        if (!moveAway && this.gameObject.transform.position != startPos)        // Move back to original position
            barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, startPos, moveSpeed * Time.fixedDeltaTime);
        else
            moveAway = true;
    }

}
