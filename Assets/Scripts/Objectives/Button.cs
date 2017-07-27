using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    // Buttons call the attached objects 
    public GameObject attachedOb;
    public float speed;
    public float pushLength;

    private Vector3 dir;
    private Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        dir = Vector3.zero;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(dir != Vector3.zero)
        {
            transform.Translate(dir * Time.deltaTime * speed);

            // If button has moved past push length.
            if(transform.position.z > startPos.z + pushLength || transform.position.z < startPos.z - pushLength)
            {
                dir = Vector3.zero;
                transform.position = startPos;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Orb")
        {
            OnPressed();
        }
    }

    public void OnPressed()
    {
        attachedOb.GetComponent<ButtonGate>().OnButtonPress();
        // If at start position, move
        if(transform.position == startPos)
            dir = transform.TransformDirection(Vector3.forward);
        this.gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
    }
}
