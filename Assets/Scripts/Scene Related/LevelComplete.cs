using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public GameObject endScreen;
    public GameObject menuScreen;
    private GameObject player;
    private int levelCount = 5;     // Amount of levels we have
    private int currentLevel;

    void Start()
    {
        player = GameObject.Find("Player");
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    public void Restart()
    {
        SaveState.Instance.checkpoint = false;
        SaveState.Instance.playerDead = false;
        SaveState.Instance.activeMenu = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentLevel);
        
    }

    public void NextLevel()
    {
        SaveState.Instance.checkpoint = false;
        SaveState.Instance.playerDead = false;
        SaveState.Instance.activeMenu = false;
        Time.timeScale = 1;
        if (currentLevel < levelCount)
            SceneManager.LoadScene(currentLevel + 1);
        else
            SceneManager.LoadScene(0);          // Incase someone actually manages to beat the game, just return to menu I guess ¯\_(ツ)_/¯
    }

    public void CheckpointRestart()
    {
        SaveState.Instance.playerDead = false;
        SaveState.Instance.activeMenu = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(currentLevel);
    }

    public void Complete()
    {
        Time.timeScale = 1;
        Destroy(SaveState.Instance);    // If we leave the level we get rid of any existing checkpoint
        SceneManager.LoadScene(0);          // 0 is main menu scene
    }

    // Need to get rid of the crosshair for the overlay like this
    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.name == "Player")
        {
            hit.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().GetMouseLook().SetCursorLock(false);
            //SaveState.Instance.playerDead = true;           // Dead for the purposes of disabling movement and firing
            SaveState.Instance.activeMenu = true;
            endScreen.SetActive(true);
            player.GetComponent<Crosshair>().create = false;
        }
    }

    public void Resume()
    {
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().GetMouseLook().SetCursorLock(true);
        menuScreen.SetActive(false);
        player.GetComponent<Crosshair>().create = true;
        Time.timeScale = 1;
        SaveState.Instance.activeMenu = false;
    }
}
