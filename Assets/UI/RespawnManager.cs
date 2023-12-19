using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour
{
    public GameObject panelRespawn; // assign in the editor
    public Button buttonYes;
    public Button buttonNo;
    void Start()
    {
        panelRespawn = GameObject.Find("Canvas/PanelRespawn");
        GameObject buttonYesGameObject = GameObject.Find("Canvas/PanelRespawn/ButtonYes");
        buttonYes = buttonYesGameObject.GetComponent<Button>();
        GameObject buttonNoGameObject = GameObject.Find("Canvas/PanelRespawn/ButtonNo");
        buttonNo = buttonNoGameObject.GetComponent<Button>();

        // Subscribe to button events
        buttonYes.onClick.AddListener(HandleButtonOnYesClicked);
        buttonNo.onClick.AddListener(HandleButtonOnNoClicked);
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

    public void HandleButtonOnYesClicked()
    {
        // Optional: Unpause the game if it was paused
        Time.timeScale = 1f;
        // Respawn player at last checkpoint
        // mainCharacterHealth.RespawnAtLastCheckpoint();

        // Hide the panel after respawning
        panelRespawn.SetActive(false);
    }

    public void HandleButtonOnNoClicked()
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
