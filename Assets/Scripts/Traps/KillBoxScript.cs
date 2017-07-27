using UnityEngine;
using System.Collections;

public class KillBoxScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.name == "Player") {
			
			Destroy (other.gameObject);

		}
	}
}