using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RespawnManager1 : MonoBehaviour
{
    public GameObject panelRespawn; // assign in the editor
    public Button buttonYes;
    public Button buttonNo;
    public MainCharacterHealth mainCharacterHealth; // assign in the editor

    private void Awake()
    {
        // Subscribe to button events
        buttonYes.onClick.AddListener(OnYesClicked);
        buttonNo.onClick.AddListener(OnNoClicked);

        // Hide panel at start
        panelRespawn.SetActive(false);
    }

    // Call this method when the player dies
    public void ShowRespawnPanel()
    {
        Debug.Log("ShowRespawnPanel called");
        panelRespawn.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void OnYesClicked()
    {
        // Optional: Unpause the game if it was paused
        Time.timeScale = 1f;

        // Respawn player at last checkpoint
        // mainCharacterHealth.RespawnAtLastCheckpoint();

        // Hide the panel after respawning
        panelRespawn.SetActive(false);
    }

    public void OnNoClicked()
    {
        // Optional: Unpause the game if it was paused
        // Time.timeScale = 1f;

        // Load the Main Menu scene
        SceneManager.LoadScene("MainMenu");
    }

    // Call this method to hide respawn panel and unpause if needed
    public void HideRespawnPanel()
    {
        // Optional: Unpause the game if it was paused
        // Time.timeScale = 1f;

        panelRespawn.SetActive(false);
    }
}
