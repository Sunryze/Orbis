using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public Texture2D crosshair;
	public Rect position;
    public bool create;
	// Use this for initialization
	void Start () {
        create = true;
	}
	
	// Update is called once per frame
	void Update () {
		position = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) /2, crosshair.width, crosshair.height);
	}
	void OnGUI() {
        if (create)
		    GUI.DrawTexture (position, crosshair, ScaleMode.ScaleToFit, true);
	}

    public void Remove()
    {
        
    }
}