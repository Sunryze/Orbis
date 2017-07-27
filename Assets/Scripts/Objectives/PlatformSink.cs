using UnityEngine;
using System.Collections;

public class PlatformSink : MonoBehaviour {

    /*      
     *     Assign the movement speed and the distance it has travel
     */

    public GameObject targetOb;
    public float moveSpeed = 1;
    public float distanceGoal;
    private float currentDistance = 0;
    private bool moveOb;
	public bool goal;
    private PressurePadTarget script;
    private GameObject child;
    private GameObject player;


    //audio
    public AudioClip squish;
    public AudioClip loopsquish;
    public AudioClip complete;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        script = targetOb.GetComponent<PressurePadTarget>();
        child = this.gameObject.transform.GetChild(0).gameObject;
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moveOb && !goal)       // Move to designated position
		{
            // play squish noise not working as intended
            if (audioSource.clip != squish)
            {
                audioSource.loop = true;
                audioSource.clip = loopsquish;
                audioSource.Play();
            }
			if(currentDistance >= distanceGoal)
				goal = true;
            else {
				currentDistance += moveSpeed * Time.fixedDeltaTime;
                transform.Translate(Vector3.down * moveSpeed * Time.fixedDeltaTime);                
                player.transform.parent = null;                                                     // need to detact player and reattach when scaling otherwise player gets scaled
                transform.localScale -= new Vector3(0, moveSpeed * Time.fixedDeltaTime / 5, 0);     // dunno why divide by 5 to make it work, just is
                player.transform.parent = transform;
			}
	    }

		if(goal)        // When object has moved to target position, we increment the amount of presses of the target wall and disable this script
        {
            //Audio stuff
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = complete;
            audioSource.Play();

            script.pressCounter += 1;
            this.enabled = false;
            child.GetComponent<Renderer>().material.color = new Color(0f, 0.25f, 0, 1);
        }

  
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.name == "Player") // when the player hits the obstacle the platform begins moving
        {
            audioSource.clip = squish;
            if (!goal)  
                audioSource.Play();
            moveOb = true;
            hit.transform.parent = transform;
        }
    }


    
    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.name == "Player") // when the player hits the obstacle the platform begins moving
        {
			hit.transform.parent = null;
			moveOb = false;
            //stop squish noise if u get off
            if(audioSource.clip == loopsquish)
                audioSource.Stop();
		}
	}


}
