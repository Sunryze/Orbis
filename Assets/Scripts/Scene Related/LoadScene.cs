using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    public int level;
    public GameObject menu;
    public GameObject controls;
    public GameObject credits;
    public GameObject levels;
    public GameObject imagePreview;
    public Texture[] previews;
    private bool menuControl;
    private bool menuLevel;
    private bool menuCredits;

    void Start()
    {
        controls.SetActive(false);
        levels.SetActive(false);
        credits.SetActive(false);
    }

	public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelSelect()
    {
        level = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        imagePreview.GetComponent<RawImage>().texture = previews[level-1];
    }

    public void MenuControls()
    {
        if (!menuControl)
        {
            menuControl = true;
            menu.SetActive(false);
            controls.SetActive(true);
        }
        else
        {
            menuControl = false;
            menu.SetActive(true);
            controls.SetActive(false);
        }
    }

    public void MenuCredits()
    {
        if (!menuCredits)
        {
            menuCredits = true;
            menu.SetActive(false);
            credits.SetActive(true);
        }
        else
        {
            menuCredits = false;
            menu.SetActive(true);
            credits.SetActive(false);
        }
    }

    public void MenuLevels()
    {
        if(!menuLevel)
        {
            level = 1;
            menuLevel = true;
            menu.SetActive(false);
            levels.SetActive(true);
        }
        else
        {
            menuLevel = false;
            menu.SetActive(true);
            levels.SetActive(false);
        }
    }
}
