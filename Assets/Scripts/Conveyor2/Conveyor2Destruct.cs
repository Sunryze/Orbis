using UnityEngine;
using System.Collections;

public class Conveyor2Destruct : MonoBehaviour
{

    public GameObject platform;
    private GameObject player;
    //private GameObject startPlatform;

    // Use this for initialization
    void Start()
    {
        //startPlatform = GameObject.Find("Stage2Start");
        player = GameObject.Find("Player");

        // Disable all destruction objects before stage 2 starts.
        foreach(C2DestructPlatform platform  in Resources.FindObjectsOfTypeAll<C2DestructPlatform>())
        {
            if(!platform.gameObject.GetComponent<C2DestructPlatform>().startActive)
                platform.gameObject.SetActive(false);
        }
            
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDestruction()
    {
        // Should make explosion effects indicating that level is destructing.

        // Grab all platform markers, make new platforms there.
        foreach (GameObject mark in GameObject.FindGameObjectsWithTag("C2PlatformMarker"))
            Instantiate(platform, mark.transform.position, mark.transform.rotation);

        foreach (C2DestructPlatform platform in Resources.FindObjectsOfTypeAll<C2DestructPlatform>())
        {
            platform.gameObject.SetActive(true);
            platform.gameObject.GetComponent<C2DestructPlatform>().active = true;
        }
         
        if(GameObject.Find("Cannon"))   
            GameObject.Find("Cannon").SetActive(false);
        player.GetComponent<Player>().savedCheckpoint = new Vector3(17.01f, 25.94f, -49.05f);
    }
}
