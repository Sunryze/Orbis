using UnityEngine;
using System.Collections;

public class LevelSettings : MonoBehaviour {

    // The starting point of the player for this level.
    public Vector3 StartPoint;
    public ScriptableObject targetScript;

	// Use this for initialization
	void Start () {

        // If no start point specified, will set the position of this object as start.
        if (StartPoint == Vector3.zero)
            StartPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void RespawnPlayer (GameObject player)
    {
        player.transform.position = StartPoint;
    }
}
