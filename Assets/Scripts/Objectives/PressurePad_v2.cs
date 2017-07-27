using UnityEngine;
using System.Collections;

public class PressurePad_v2 : MonoBehaviour {

    public GameObject attachedOb;       // Set to the target object to show/hide
    public bool requireStay;            // Set to true if the pad deactivates when player leaves
    private bool activated;
    private PressurePadTarget script;
    private Renderer rend;

    //Audio
    public AudioClip buttonOn;
    public AudioClip buttonOff;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        script = attachedOb.GetComponent<PressurePadTarget>();
        rend = gameObject.GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (activated)
            rend.material.color = new Color(0, 1, 0, 1);
        else
            rend.material.color = new Color(1, 0.92f, 0.16f, 1);
	}

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Player" && !activated)
        {
            activated = true;
            script.pressCounter += 1;
            // play sound
            audioSource.clip = buttonOn;
            audioSource.Play();
        }
    }

    void OnCollisionExit(Collision hit)
    {
        if(requireStay && activated)
        {
            if(hit.gameObject.tag == "Player")
            {
                activated = false;
                script.pressCounter -= 1;
                // play sound
                audioSource.clip = buttonOff;
                audioSource.Play();
            }
        }
    }
}
