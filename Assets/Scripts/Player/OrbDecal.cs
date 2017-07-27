using UnityEngine;
using System.Collections;

public class OrbDecal : MonoBehaviour
{
    GameObject orb;
    Material mat;

    // Use this for initialization
    void Start()
    {
        orb = GameObject.Find("Orb");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Attempt to apply decal to target. Assumes orb has hit target.
    public void ApplyDecal(ContactPoint point)
    {
        // Adjust decal position to orb pos
        transform.position = orb.transform.position;

        // Rotate decal to face away from wall. 
        Vector3 fromTo = Quaternion.FromToRotation(Vector3.forward, point.normal).eulerAngles;
        Vector3 rotation = new Vector3(fromTo.x * -1, fromTo.y - 180, 0);
        transform.rotation = Quaternion.Euler(rotation);
    }
}
    