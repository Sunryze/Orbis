using UnityEngine;
using System.Collections;

public class ButtonGate : MonoBehaviour
{

    // Position of the gate when open
    public Vector3 GateOpenPos;
    public Vector3 GateClosedPos;
    public float speed;
    public float openTime;

    // Can operate with a companion gate to have a top and bottom.
    public GameObject GateCompanion;
    //private Vector3 CompanionStartPos;

    private Vector3 dir;
    private Vector3 targetPos;
    private float timeRemaining;

    // Use this for initialization
    void Start()
    {
        dir = Vector3.zero;
        //if (GateCompanion)
        //    CompanionStartPos = GateCompanion.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(dir != Vector3.zero)
        {
            // If gate must move towards target position, translate towards dir.
            transform.Translate(dir * Time.deltaTime * speed);

            // If gate has companion part, move companion in opposite direction.
            if(GateCompanion)
                GateCompanion.transform.Translate(-1 * dir * Time.deltaTime * speed);

            // Check if gate has moved past target position.
            if((targetPos - transform.position).normalized != dir)
            {
                // Set position to target, stop moving.
                transform.position = targetPos;
                dir = Vector3.zero;

                // If target was open, start counting down till gate close.
                if(targetPos == GateOpenPos)
                {
                    timeRemaining = openTime;
                }
                targetPos = Vector3.zero;
            }
        }   
    }

    void FixedUpdate()
    {
        // If gate is counting down.
        if(timeRemaining > 0)
        {
            timeRemaining -= 0.02f;
        }
        // Gate is out of time.
        if(timeRemaining < 0 && timeRemaining > -1)
        {
            targetPos = GateClosedPos;
            dir = (targetPos - transform.position).normalized;
            timeRemaining = -1;
        }
    }

    // Move gate to open position. Reset close timer if already at open position. Do nothing otherwise.
    public void OnButtonPress()
    {
        if (transform.position == GateClosedPos)
        {
            targetPos = GateOpenPos;
            dir = (targetPos - transform.position).normalized;
        }
    }
}
