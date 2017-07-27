using UnityEngine;
using System.Collections;

public class LaserIndicator : MonoBehaviour {

    public float rate = 0.1f;
    private GameObject hori;
    private GameObject vert;
    private GameObject orb;
    private GameObject cam;
    private float red = 1.0f;
    private float green = 0.92f;
    private float blue = 0.016f;
    private float alpha = 0.05f;
    

	// Use this for initialization
	void Start () {
        orb = GameObject.Find("Player");
        cam = GameObject.Find("MainCamera");
        hori = GameObject.Find("LaserH");
        vert = GameObject.Find("LaserV");
        hori.SetActive(false);
        vert.SetActive(false);
        hori.GetComponent<Renderer>().material.color = new Color(red, blue, green, alpha);
        vert.GetComponent<Renderer>().material.color = new Color(red, blue, green, alpha);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowLaser()
    {
        hori.SetActive(true);
        vert.SetActive(true);
        hori.transform.rotation = orb.transform.rotation;
        vert.transform.rotation = cam.transform.rotation;
        hori.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        vert.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        red = 1.0f;
        green = 0.92f;
        blue = 0.016f;
        hori.GetComponent<Renderer>().material.color = new Color(red, green, blue, alpha);
        vert.GetComponent<Renderer>().material.color = new Color(red, green, blue, alpha);
    }

    public void HideLaser()
    {
        hori.SetActive(false);
        vert.SetActive(false);
    }

    public void ExpandLaser()
    {
        hori.transform.localScale += new Vector3(rate, 0, 0);
        vert.transform.localScale += new Vector3(0, rate / 2, 0);
    }

    public void LaserColor()
    {
        green -= 0.01f;
        hori.GetComponent<Renderer>().material.color = new Color(red, green, blue, alpha);
        vert.GetComponent<Renderer>().material.color = new Color(red, green, blue, alpha);
    }
}
