using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OrbContainer : MonoBehaviour {

    public GameObject activatedObject;

    GameObject player;
    GameObject orb;
    ParticleSystem orbP;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	}

    // Called when orb collides with this container.
    public void ActivateContainer()
    {
        player.GetComponent<LaunchOrb>().DisableOrb();
        // If level is conveyor 2, call destruction.
        if(SceneManager.GetActiveScene().name.Equals("conveyor2"))
        {
            if(GetComponent<Conveyor2Destruct>() != null)
            {
                GetComponent<Conveyor2Destruct>().StartDestruction();
            }
        }
    }

    public void ReleaseOrb()
    {
        player.GetComponent<LaunchOrb>().EnableOrb();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            other.GetComponent<LaunchOrb>().DisableOrb();
        }
    }
}
