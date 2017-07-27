using UnityEngine;
using System.Collections;
using System;

public class OrbIndicator : MonoBehaviour
{

    // Orb indicator does not show on any gameobject tagged with one of these tags.
    public string[] filteredTags;

    private Transform orbTF;
    private bool active;
    private LaunchOrb orb;
    private ParticleSystem wispP;

    // Use this for initialization
    void Start()
    {
        transform.parent = null;
        orbTF = GameObject.Find("Orb").transform;
        orb = GameObject.Find("Player").GetComponent<LaunchOrb>();
        wispP = GameObject.Find("Indicator wisps").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (active && orb.launched)
        {
            var emitOverride = new ParticleSystem.EmitParams();
            emitOverride.startSize3D = new Vector3(0.8f, (orbTF.position.y - transform.position.y) / 2, 1);
            wispP.Emit(emitOverride, 1);
        }
    }

    void FixedUpdate()
    {    
        // Raycast to find closest ground position.
        RaycastHit hit;
        Ray ray = new Ray(orbTF.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (Array.IndexOf(filteredTags, hit.transform.tag) > -1)
            {
                if (active && orb.launched)
                {
                    Deactivate(gameObject);
                }
            }
            else
            {
                if (!active && orb.launched)
                    Activate(gameObject);
            }                   
            Vector3 hitPos = hit.point;
            hitPos.y += 0.001f;
            transform.position = hitPos;
        }
    }

    // Activate orb ground indicator.
    public void Activate(GameObject ob)
    {
        if (ob.GetComponentsInChildren<ParticleSystem>() == null)
            return;
        foreach (ParticleSystem child in ob.GetComponentsInChildren<ParticleSystem>())
        {
            child.Play();
            if (child.gameObject != ob)
                Activate(child.gameObject);
        }
        active = true;
    }

    public void Deactivate(GameObject ob)
    {
        if (ob.GetComponentsInChildren<ParticleSystem>() == null)
            return;
        foreach (ParticleSystem child in ob.GetComponentsInChildren<ParticleSystem>())
        {
            child.Stop();
            child.Clear();
            if (child.gameObject != ob)
                Deactivate(child.gameObject);
        }
        active = false;
    }
}
