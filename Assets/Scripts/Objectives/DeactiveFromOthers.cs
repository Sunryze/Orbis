using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeactiveFromOthers : MonoBehaviour {

    public GameObject[] objects;
    private List<GameObject> listOB;
    private int  count = 0;
    private int size;

    // Use this for initialization
    void Start () {

        listOB = new List<GameObject>();

        //Adds objects in a scene with this current tag
        objects = GameObject.FindGameObjectsWithTag("OBSinkPlat");
        size = objects.Length;

        //using a list to remove elements later
        for (int i = 0; i < objects.Length; i++)
        {
            listOB.Add(objects[i]);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
        foreach(GameObject item in listOB)
        {
            if(item.GetComponent<ObjectivePlatformSink>().goal)
            {
                int i = listOB.IndexOf(item);
                listOB.RemoveAt(i);
                count++;        
            }
        }

        if (count == size )
        {
            gameObject.SetActive(false);
        }
	}


}
