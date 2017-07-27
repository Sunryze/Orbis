using UnityEngine;
using System.Collections;

public class BouncePad : MonoBehaviour
{
    public float jumpForce;
    private GameObject player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.name == player.name && rb.velocity.y <= 0)
        {
            rb.AddForce(new Vector3(0,rb.velocity.y * rb.velocity.magnitude,0), ForceMode.Force);
        }
    }
}