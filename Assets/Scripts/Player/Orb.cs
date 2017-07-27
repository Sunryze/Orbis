using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour
{

    private GameObject cam;
    private GameObject decal;
    private GameObject orbP;
    private LaunchOrb launchOrb;

    //audio for sound
    public AudioClip orbshot;
    public AudioClip orbhit;
    public AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        launchOrb = GameObject.Find("Player").GetComponent<LaunchOrb>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        transform.parent = cam.transform;
        orbP = GameObject.Find("OrbParticle");
        Physics.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider>(), GetComponent<Collider>());  // Orb ignores player collision
        decal = GameObject.Find("OrbDecal");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLaunched()
    {
        audioSource.clip = orbshot;
        audioSource.Play();
        Activate(orbP);
    }


    // Activate orb pariticles
    public void Activate(GameObject ob)
    {
        if (ob.GetComponentsInChildren<ParticleSystem>() == null)
            return;
        foreach (ParticleSystem child in ob.GetComponentsInChildren<ParticleSystem>())
        {
            child.Clear();
            child.Play();
            var col = child.colorOverLifetime;
            col.enabled = true;
            if (child.gameObject != ob)
                Activate(child.gameObject);
        }
    }

    public void Deactivate(GameObject ob)
    {
        if (ob.GetComponentsInChildren<ParticleSystem>() == null)
            return;
        foreach (ParticleSystem child in ob.GetComponentsInChildren<ParticleSystem>())
        {
            var col = child.colorOverLifetime;
            col.enabled = false;
            child.Clear();
            if (child.gameObject != ob)
                Deactivate(child.gameObject);
        }
    }

    public void OnReturned()
    {
    

        Deactivate(orbP);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("OrbContainer"))
            col.gameObject.GetComponent<OrbContainer>().ActivateContainer();
        else
        {
            if (launchOrb.launched)
            {             
                foreach (ContactPoint contact in col.contacts)
                {
                    decal.GetComponent<OrbDecal>().ApplyDecal(contact);
                }
            }
            launchOrb.OrbToPlayer();
            
        }
    }
}
