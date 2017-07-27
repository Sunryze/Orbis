using UnityEngine;
using System.Collections;

/*      Pair this script with an object that has PressurePadTarget script attached
 *  
 *      Current problems: Even if it has been activated successfully the button will still turn red once the duration is up, but gate will remain open
 */ 

public class Button_Instant : MonoBehaviour {

    public GameObject attachedOb;       // Set to the target object to show/hide

    private bool activated;
    private PressurePadTarget script;
    private Renderer rend;
    public Mesh greenTarget;

    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        script = attachedOb.GetComponent<PressurePadTarget>();
        audioSource = GetComponent<AudioSource>();
   //     rend.material.color = new Color(1, 0, 0, 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Renderer>().material.color = new Color(0.7f, 0, 0, 1);
            
        }
        
	}

    void OnCollisionEnter(Collision hit)
    {
        if((hit.gameObject.tag == "Player" || hit.gameObject.tag == "Orb" ) && !activated)
        {
            activated = true;
            script.pressCounter += 1;
            // play sound
            audioSource.Play();

            transform.GetComponent<MeshFilter>().mesh = greenTarget;
            for (int i = 0; i < transform.childCount; i++)
            {
                //transform.GetChild(i).GetComponent<Renderer>().material.color = new Color(0, 0.6f, 0, 0.5f);
                transform.GetChild(i).GetComponent<Renderer>().enabled = false;
                transform.GetChild(i).GetComponent<BoxCollider>().enabled = false;
                //rend.material.color = new Color(0, 0.8f, 0, 1);
            }
        }
    }
}
