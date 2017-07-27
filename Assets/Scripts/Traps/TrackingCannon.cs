using UnityEngine;
using System.Collections;

public class TrackingCannon : MonoBehaviour {

    public GameObject projectile;
    public float visionRange;
    public float visionRadius;
    public float turnSpeed;

    private GameObject player;
    private bool canSeePlayer;
    private bool onCooldown = false;
    private bool cannonOn = true;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(cannonOn)
        {
            if (canSeePlayer)
            {
                Vector3 newDir = Vector3.RotateTowards(transform.forward, player.transform.position - transform.position, turnSpeed, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);

                if (!onCooldown)
                {
                    // Fire a new projectile
                    GameObject shot = Instantiate(projectile);
                    shot.transform.position = transform.position + 2 * transform.forward;
                    shot.GetComponent<Rigidbody>().AddForce(20 * transform.forward, ForceMode.Impulse);
                    StartCoroutine(CannonCooldown());
                }
            }
        }
	}

    void FixedUpdate()
    {
        if(cannonOn)
        {
            // Cannon tries to find player.
            RaycastHit[] hit;
            Vector3 rayDir = player.transform.position - transform.position;
            Ray playerCheck = new Ray(transform.position, rayDir);
            hit = Physics.RaycastAll(playerCheck, visionRange);
            bool playerFound = false;
            bool inVisionRange = false;
            foreach (RaycastHit target in hit)
            {
                if (target.collider.name.Equals("Player"))
                    playerFound = true;
            }
            if (playerFound)
                inVisionRange = (Vector3.Angle(rayDir, transform.forward)) < visionRadius / 2;
            canSeePlayer = playerFound && inVisionRange;
        }
    }

    IEnumerator CannonCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(3);
        onCooldown = false;
    }
}
