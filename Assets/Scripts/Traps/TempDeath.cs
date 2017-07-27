using UnityEngine;
using System.Collections;

public class TempDeath : MonoBehaviour {

    public bool active = true;

    private LevelSettings levelS;
    private LevelFailed script;

    void Start()
    {
        script = GameObject.Find("EndGate").GetComponent<LevelFailed>();
    }

    void OnTriggerEnter(Collider hit)
    {
        if(active)
        {
            if (hit.gameObject.name == "Player")
            {
                script.ShowScreen();
            }
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if(active)
        {
            if (hit.gameObject.name == "Player")
            {
                script.ShowScreen();
            }
        }
    }
}


