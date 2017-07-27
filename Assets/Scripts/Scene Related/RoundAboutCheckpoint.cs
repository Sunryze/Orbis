using UnityEngine;
using System.Collections;

public class RoundAboutCheckpoint : MonoBehaviour {

    public GameObject spawnOb;

	// Use this for initialization
	void Start () {
        if (SaveState.Instance.checkpoint)
            spawnOb.GetComponent<PressurePadTarget>().pressCounter++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
