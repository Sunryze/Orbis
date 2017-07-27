using UnityEngine;
using System.Collections;

public class DeactivateObjects : MonoBehaviour {

    public GameObject[] obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision hit)
    {
        if ((hit.gameObject.tag == "Player" || hit.gameObject.tag == "Orb"))
        {
            foreach(GameObject item in obj)
            {
                item.GetComponent<Renderer>().enabled = false;
                item.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
