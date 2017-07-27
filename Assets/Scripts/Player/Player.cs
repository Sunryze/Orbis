using UnityEngine;
using System.Collections;
using System.Timers;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;
using System.Linq;


public class Player : MonoBehaviour
{

    public Rigidbody rb;
    //public float cooldown = 3;
    private float maxDownVel = 0;
    public Vector3 savedCheckpoint;

    private Transform camTF;
    public GameObject menuScreen;
    private GameObject endGate;
    public AudioClip footsteps;
    public AudioClip death;
    public AudioSource audioSource;

    /*
    public int maxCharges = 3;
    public Texture blinkLoad; //= UnityEditor.AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures/Orb_diffuse.psd");
    public Texture blinkReady; //= UnityEditor.AssetDatabase.LoadAssetAtPath<Texture>("Assets/Textures/blink.psd");
    private Stopwatch cdTimer;
    private int curCharges;
    private bool[] Charges;
    private double timeElapsed;
    private GameObject[] blinkObs;
    GameObject cdOb;
    RawImage cdImg;*/

    // Use this for initialization
    void Start()
    {
        //footsteps = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Sounds/walk.mp3");
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        savedCheckpoint = transform.position;
        camTF = transform.Find("MainCamera");
        endGate = GameObject.Find("EndGate");
        /*
        curCharges = maxCharges;
        cdOb = GameObject.Find("BlinkCooldown");
        cdImg = cdOb.GetComponent<RawImage>();
        cdTimer = new Stopwatch();
        blinkObs = GameObject.FindGameObjectsWithTag("BlinkIcon").OrderBy(go => go.name).ToArray();
        */
        if (SaveState.Instance.checkpoint)        // Respawn at the last checkpoint visited
        {
            gameObject.transform.rotation = Quaternion.Euler(0, SaveState.Instance.rotY, 0);
            gameObject.transform.position = SaveState.Instance.spawnPos;
            savedCheckpoint = SaveState.Instance.spawnPos;
        }
    }

    /*void OnGUI()
    {
        // Make blink icons on sceen.
        

        // If there is a blink charge restoring, draw it.
        if (GetCurCharges() < maxCharges)
        {
            // If currently restoring charge is enabled, disable it.
            if (blinkObs[GetCurCharges()].GetComponent<RawImage>().enabled)
                blinkObs[GetCurCharges()].GetComponent<RawImage>().enabled = false;
            // Move cooldown image to cover blink charge that needs restoring.
            cdImg.transform.position = blinkObs[GetCurCharges()].transform.position;
            float degrees = cdTimer.ElapsedMilliseconds / cooldown * 2 * Mathf.PI * (180 / Mathf.PI) * -1;
            cdImg.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degrees));
            cdImg.enabled = true;
        }
        else
        {
            cdImg.enabled = false;
        }
    }*/

    // Update is called once per frame
    void Update()
    {

        //Walk Sound
       if ((Input.GetButtonDown("Vertical") || (Input.GetButtonDown("Horizontal"))) && !audioSource.isPlaying)
        {
           
            audioSource.clip = footsteps;
            audioSource.Play();
            
       }

      if ((Input.GetButtonUp("Vertical") || (Input.GetButtonUp("Horizontal"))) && audioSource.isPlaying)
        {
          audioSource.Stop();     
        }

     


        if (Input.GetButtonDown("Reset"))
        {
            gameObject.transform.position = savedCheckpoint;
            rb.velocity = new Vector3(0, 0, 0);
        }

        // Press esc to access menu here
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!SaveState.Instance.activeMenu)
            {
                GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().GetMouseLook().SetCursorLock(false);
                menuScreen.SetActive(true);
                SaveState.Instance.activeMenu = true;
                Time.timeScale = 0;
                GetComponent<Crosshair>().create = false;
            }
            else
            {
                GameObject.Find("EndGate").GetComponent<LevelComplete>().Resume();
            }
            
        }

        // Player interact action, currently looks for a button 1m ahead of player and calls .OnPressed() on it
        if (Input.GetButtonDown("Interact"))
        {
            Vector3 forward = camTF.TransformDirection(Vector3.forward) * 4;
            RaycastHit hit;
            Ray r = new Ray(camTF.position, forward);
            if (Physics.Raycast(r, out hit, 1f))
            {
                if (hit.collider.tag == "Button")
                {
                    hit.collider.gameObject.GetComponent<Button>().OnPressed();
                }
            }
        }

        float roty = gameObject.transform.eulerAngles.y;
        gameObject.transform.eulerAngles = new Vector3(0, roty, 0);

        /*
        // Check for cooldown timer pop
        if (cdTimer.IsRunning)
            if (cdTimer.ElapsedMilliseconds > cooldown)
                CooldownEnd();*/
    }

    // Physics things go here
    void FixedUpdate()
    {
        // While player is moving down, keep storing the max downward velocity.
        if (rb.velocity.y <= 0)
        {
            if (rb.velocity.y < maxDownVel)
            {
                maxDownVel = rb.velocity.y;
            }
        }

        // Check for platforms below player (bounce pads etc). (should refactor into bouncepad.cs)
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, 1f))
        {
            if (hit.collider.tag.Equals("BouncePad"))
            {
                rb.AddForce(new Vector3(0, 25, 0), ForceMode.Impulse);
            }
            // Reset maxdownvel
            else
            {
                maxDownVel = 0;
            }
        }

        // Attempt to find objects that have moved inside the player and call a death.
        Collider[] cols = Physics.OverlapSphere(transform.position, 0.2f);
        foreach (Collider col in cols)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("KillLayer"))
            {
                endGate.GetComponent<LevelFailed>().ShowScreen();
            }
        }
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1f);
    }
    /*
    // Returns true if player has an orb charge to teleport with.
    public bool HasCharge()
    {
        if (curCharges > 0)
            return true;
        return false;
    }

    // Spends an orb charge for the player.
    public void SpendCharge()
    {
        curCharges--;
        PlayerCooldown();
    }

    void PlayerCooldown()
    {
        // Start timer if not running.
        if (!cdTimer.IsRunning)
        {
            cdTimer.Start();
        }
    }*/

    public void Death(GameObject killer)
    {
        
        if (killer.tag == "LaserWall")
            print("Died to laser");
    }
    /*
    void CooldownEnd()
    {
        // Add a charge.
        AddCharge();
        cdTimer.Reset();

        // If more charges need to be restored, start timer again.
        if (curCharges < maxCharges)
            cdTimer.Start();

        // If hit max charges, reset & stop timer.
        if (curCharges == maxCharges)
            cdTimer.Stop();
    }

    public int GetCurCharges()
    {
        return curCharges;
    }

    void AddCharge()
    {
        // Enable blink image if disabled.
        if (!blinkObs[curCharges].GetComponent<RawImage>().enabled)
            blinkObs[curCharges].GetComponent<RawImage>().enabled = true;

        if (curCharges < maxCharges)
            curCharges++;
    }*/
}
