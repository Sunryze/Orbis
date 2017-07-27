using UnityEngine;
using System.Collections;

public class PlatformNode : MonoBehaviour {

    public bool isStart;
    public bool isEnd;
    public GameObject nextNode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "PathPlatform")
        {
            col.GetComponent<PathingPlatform>().OnNodeHit(this.gameObject);
        }
    }
}
