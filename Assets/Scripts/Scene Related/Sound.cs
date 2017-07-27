using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip bgm;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.mute = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.mute = !audioSource.mute;
        }

    }
}
