using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public Vector3 checkpointPos;

	// Use this for initialization
	void Start () {
        checkpointPos = gameObject.transform.position;
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.name == "Player") //overwrites the currents players checkpoint
        {
            SaveState.Instance.checkpoint = true;
            SaveState.Instance.rotY = gameObject.transform.eulerAngles.y;
            SaveState.Instance.spawnPos = checkpointPos;
            Destroy(this.gameObject);
        }
    }
}
