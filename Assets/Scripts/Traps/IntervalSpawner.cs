using UnityEngine;
using System.Collections;

public class IntervalSpawner : MonoBehaviour {

    public float interval;
    public float startDelay;
    public bool randomRotation;
    public GameObject prefab;
    public float xInit;         // x,y,z coordinates of start according to worldspace
    public float yInit;
    public float zInit;
    public float xMove;         // x,y,z coordinates of target position worldspace
    public float yMove;
    public float zMove;
    public float moveSpeed;
    private InstanceScript script;
    private bool updateOn;
    private float spawnDistance;      // Used to spawn them at a set distance from checkpoint
    private Vector3 dir;
    private Vector3 startPos;
    private Vector3 endPos;
     

	// Use this for initialization
	void Start () {
        startPos = new Vector3(xInit, yInit, zInit);
        endPos = new Vector3(xMove, yMove, zMove);
        dir = (endPos - startPos).normalized;

        if (startDelay != 0)             // If start delay is set then wait the time before we start spawning stuff, otherwise spawn at runtime
        {
            StartCoroutine(StartDelay());
            initialSpawn();
        }
        else
        {
            StartCoroutine(SpawnInterval());
            initialSpawn();
        }
            
	}
	
	IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(SpawnInterval());
    }

    IEnumerator SpawnInterval()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        if (randomRotation)
        {
            float random = Random.Range(0f, 360f);
            int zRot;
            if (random <= 90)
                zRot = 0;
            else if (random <= 180)
                zRot = 90;
            else if (random <= 270)
                zRot = 180;
            else
                zRot = 270;
            rotation = Quaternion.Euler(0, 0, zRot);
        }
        GameObject wall = (GameObject)Instantiate(prefab, new Vector3(xInit, yInit, zInit), rotation);
        script = wall.AddComponent<InstanceScript>();       // This script will handle the actual movement of the prefab, we pass on the target location to that script
        script.xMove = xMove;
        script.yMove = yMove;
        script.zMove = zMove;
        script.moveSpeed = moveSpeed;
        script.startMovement = true;
        yield return new WaitForSeconds(interval);
        StartCoroutine(SpawnInterval());
    }

    public void initialSpawn()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        if (randomRotation)
        {
            float random = Random.Range(0f, 360f);
            int zRot;
            if (random <= 90)
                zRot = 0;
            else if (random <= 180)
                zRot = 90;
            else if (random <= 270)
                zRot = 180;
            else
                zRot = 270;
            rotation = Quaternion.Euler(0, 0, zRot);
        }

        while(spawnDistance <= Vector3.Distance(startPos, endPos))        // Gradually spawn the lasers further and further away until spawndistance reaches the max point the laser can move to
        {
            spawnDistance += moveSpeed * Time.fixedDeltaTime * 1000 + startDelay;  
            Vector3 spawnPoint = startPos + dir * spawnDistance;        // Get the point 'x' units in the direction it should move towards
            GameObject wall = (GameObject)Instantiate(prefab, spawnPoint, rotation);
            script = wall.AddComponent<InstanceScript>();       // This script will handle the actual movement of the prefab, we pass on the target location to that script
            script.xMove = xMove;
            script.yMove = yMove;
            script.zMove = zMove;
            script.moveSpeed = moveSpeed;
            script.startMovement = true;
            
        }
        
    }
}
