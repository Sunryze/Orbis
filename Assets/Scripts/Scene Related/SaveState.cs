using UnityEngine;
using System.Collections;

public class SaveState : MonoBehaviour {

    public static SaveState Instance;
    public bool checkpoint;
    public Vector3 spawnPos;      // The position the player will spawn in, decide this through the 'Checkpoint' script
    public float rotY;          // Rotation the player will spawn with, make sure to set the facing direction of the checkpoint itself
    public bool playerDead;    // Keep track of player being dead or alive for menu stuff
    public bool activeMenu;

    // Make sure that only one instance is in the scene at a time, if it exists this will override the new one
    void Awake()
    {
        transform.parent = null;
        if(Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else if (Instance != null)
            Destroy(gameObject);
    }
}
