using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSwap : MonoBehaviour {

    public GameObject ImageOnPanel;  ///set this in the inspector
    public Texture NewTexture;
    private RawImage img;

    void Start()
    {
        img = (RawImage)ImageOnPanel.GetComponent<RawImage>();

        img.texture = (Texture)NewTexture;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
