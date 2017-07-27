using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFailed : MonoBehaviour {

    public GameObject deathScreen;
    public GameObject deathText;
    public float maxAlpha;
    public float fadeSpeed;
    private float alpha;
    private Image image;
    private ScreenFade fade;
    public float fadeTime;

    private bool playOnce;

    void Start()
    {
        playOnce = true;
        fade = deathScreen.GetComponent<ScreenFade>();
        fade.SetScreenOverlayColor(new Color(0, 0, 0, 0));
        alpha = 0;
        image = deathScreen.GetComponent<Image>();
        image.color = new Color(0, 0, 0, alpha);
        deathText.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.2f, 0));   // Positions the deathtext to be halfway of screen, 0.2 of screen height
    }

    void Update()
    {
        if(SaveState.Instance.playerDead && Input.GetButtonDown("Fire1"))
        {
            image.color = new Color(0, 0, 0, 0);
            SaveState.Instance.playerDead = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(SaveState.Instance.playerDead)
        {
            // Play death sound onces
            if (playOnce)
            {
                deathScreen.GetComponent<ScreenFade>().SoundEffect();
            }
            playOnce = false;

            if (alpha <= maxAlpha)
            {
                alpha += fadeSpeed * Time.deltaTime;
                image.color = new Color(0, 0, 0, alpha);
            }
            else
            {              
                deathText.SetActive(true);
            }
                
        }
    }

    public void ShowScreen()
    {
        SaveState.Instance.playerDead = true;
        GameObject.Find("Player").GetComponent<Crosshair>().create = false;
        GameObject.Find("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        fade.StartFade(new Color(1.0f, 0, 0, 0.3f), fadeTime / 2);
        StartCoroutine(FadeOut(fadeTime / 2));
        // Grab any pathing platforms in the level and reset them.
        GameObject[] plaftorms = GameObject.FindGameObjectsWithTag("PathPlatform");
        foreach (GameObject p in plaftorms)
            p.GetComponent<PathingPlatform>().Reset();

        foreach (C2DestructPlatform p in Resources.FindObjectsOfTypeAll<C2DestructPlatform>())
            p.gameObject.GetComponent<C2DestructPlatform>().Reset();

        if (GameObject.Find("OrbContainer"))
            GameObject.Find("OrbContainer").GetComponent<OrbContainer>().ReleaseOrb();

    }

    IEnumerator FadeOut(float fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
        fade.StartFade(new Color(1.0f, 0, 0, 0.0f), fadeTime / 2);
    }
}
