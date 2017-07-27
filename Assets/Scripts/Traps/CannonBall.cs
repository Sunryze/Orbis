using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(SelfDestruct());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}

