using UnityEngine;
using System.Collections;

public class InstanceScript : MonoBehaviour {

    public float xMove;
    public float yMove;
    public float zMove;
    public float moveSpeed;
    public bool startMovement;
    private GameObject ob;

	// Use this for initialization
	void Start () {
        ob = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = new Vector3(xMove, yMove, zMove);
        if (startMovement)
        {   // Move to designated position
            ob.transform.position = Vector3.MoveTowards(ob.transform.position, targetPos, moveSpeed * Time.deltaTime * 2);
        }

        if(ob.transform.position == targetPos)
        {
            Destroy(ob);
        }

    }
}
