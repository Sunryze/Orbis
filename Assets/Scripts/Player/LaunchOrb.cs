using UnityEngine;
using System.Collections;

public class LaunchOrb : MonoBehaviour {

    public int speed = 200;
    public bool launched;
    public float maxDistance = 20;
    public float fadeTime = 0.3f;
    public float cooldown;
    public Rigidbody orb;
    private Vector3 lastPos;
    private GameObject player;
    private ParticleSystem orbP;
    private ScreenFade fade;
    public bool canFire;
    private float distanceTravelled;
    private float red = 1.0f;       // yellow
    private float green = 0.92f;
    private float blue = 0.016f;

    // Making another reference to orb, this time to the gameobject, probably
    // want to just grab the orb game object and its rigidbody component instead of
    // treating that as the orb itself.

    private GameObject playerOrb;

    // Refers to the script component on the orb, so that functions within Orb.cs can be called from here.
    private Orb orbScript;
    private OrbIndicator orbInd;
    private bool orbHasClearSpace;
    private bool orbEnabled = true;
    public GameObject indicator2;

    //Audio 
    public AudioClip orbteleport;
    public AudioClip orbfailed;
    public AudioSource audioSource;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        playerOrb = GameObject.Find("Orb");
        orbScript = playerOrb.GetComponent<Orb>();
        orbInd = GameObject.Find("OrbIndicator").GetComponent<OrbIndicator>();
        orbP = GameObject.Find("OrbParticle").GetComponent<ParticleSystem>();
        fade = GameObject.Find("Player").GetComponent<ScreenFade>();
        fade.SetScreenOverlayColor(new Color(0, 0, 0, 0));
        orbHasClearSpace = true;
        canFire = true;
        audioSource = GetComponent<AudioSource>();
        //indicator2 = GameObject.Find("Particle Gravity Hole");

        // Particle fix (why does this happen).
        GameObject.Find("Particle Gravity Hole").transform.parent = orbInd.gameObject.transform;
        orbInd.Deactivate(orbInd.gameObject);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && !SaveState.Instance.playerDead && !SaveState.Instance.activeMenu)
        {
            if (launched && orbEnabled)       // When it's launched, we will teleport to it on left click
            {
                //audio bit
                audioSource.clip = orbteleport;
                audioSource.Play();
                
                //teleport bit
                transform.position = orb.position;
                OrbToPlayer();
                fade.StartFade(new Color(1.0f, 0.92f, 0.016f, 0.25f), fadeTime / 2);
                StartCoroutine(FadeOut(fadeTime / 2));
            }
            else if (!launched && orbHasClearSpace && canFire)         // If not launched and other conditions are satisfied, we shoot the orb
            {
                orb.transform.position = player.transform.position + player.transform.TransformDirection(Vector3.forward * 1.5f);   // remove this line to not have ball move to centre of screen when shooting
                orb.transform.parent = null;
                 
                Vector3 target = player.transform.forward * speed * maxDistance;
                Vector3 forwardVector = (target - orb.transform.localPosition).normalized;
                orb.AddForce(forwardVector * speed);
                lastPos = orb.transform.position;
                launched = true;
                canFire = false;
                orbScript.OnLaunched();
                orbInd.Activate(orbInd.gameObject);
                
            }
            else
            {
                //Play an error sound that player can't shoot
                audioSource.clip = orbfailed;
                audioSource.Play();
            }
        }
        // Calculate distance travelled
        if (launched) {
            distanceTravelled += Vector3.Distance(orb.transform.position, lastPos);
            lastPos = orb.transform.position;
        }
        // Force orb to attach to player 
        if (!launched)
        {
            orb.transform.localPosition = new Vector3(player.transform.localPosition.x + 0.4f, player.transform.localPosition.y - 0.85f, player.transform.localPosition.z + 0.6f);
        }
        // When orb reaches max distance, return it to the player.
        if (distanceTravelled >= maxDistance)
            OrbToPlayer();
        // Change colour of orb as it nears the end of its range (2/3 of the way)
        if (distanceTravelled >= maxDistance / 2) {
            orbP.startColor = Color.Lerp(Color.blue, Color.red, Time.time / 2);
        }
    }

    void FixedUpdate()
    {
        // Check forward from orb to see if orb is too close to fire.
        orbHasClearSpace = checkClearSpace();
    }

    public void OrbToPlayer()
    {
        orbP.startColor = new Color(1, 0, 0, 1);
        distanceTravelled = 0;
        orb.velocity = Vector3.zero;
        orb.transform.parent = player.transform;
        red = 1.0f;
        green = 0.92f;
        blue = 0.016f;
        launched = false;
        orbScript.OnReturned();
        orbInd.Deactivate(orbInd.gameObject);
        StartCoroutine(CooldownTime());
    }

    // Disable orb completely.
    public void DisableOrb()
    {
        orbEnabled = false;
        orbP.Clear();
        orbP.Stop();
        playerOrb.SetActive(false);
    }

    public void EnableOrb()
    {
        orbEnabled = true;
        orbP.Play();
        OrbToPlayer();
        playerOrb.SetActive(true);
    }

    private bool checkClearSpace()
    {
        Vector3 target = player.transform.forward * speed * maxDistance;
        Vector3 forwardVector = (target - orb.transform.localPosition).normalized;
        Ray clearRay = new Ray(player.transform.position + player.transform.TransformDirection(Vector3.forward * 0.5f), forwardVector);
        RaycastHit[] hits = Physics.SphereCastAll(clearRay, 0.2f, 1f);
        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.gameObject.layer != LayerMask.NameToLayer("IgnoreOrbCast"))
            {

                return false;
            }
        }
        /* Spherecast around player, check for walls etc.
        Collider[] cols = Physics.OverlapSphere(playerOrb.transform.position, 1f);
        foreach (Collider hit in cols)
            if (hit.gameObject.layer != LayerMask.NameToLayer("IgnoreOrbCast"))
                return false;*/
        return true;
    }

    IEnumerator FadeOut(float time)
    {
        yield return new WaitForSeconds(time);
        fade.StartFade(new Color(1.0f, 0.92f, 0.016f, 0.0f), fadeTime / 2);
       
    }

    IEnumerator CooldownTime()
    {
        yield return new WaitForSeconds(cooldown);
        orbP.startColor = new Color(red, green, blue, 255);
        orbScript.Deactivate(playerOrb);
        canFire = true;
    }
}