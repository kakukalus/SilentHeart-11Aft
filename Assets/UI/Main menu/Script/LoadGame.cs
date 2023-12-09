using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        // Load data dari PlayerPrefs
        Vector3 checkpointPosition = SaveSystem.LoadCheckpointPosition();
        float playerHealth = SaveSystem.LoadPlayerHealth();
        int currentLevel = SaveSystem.LoadCurrentLevel();

        // Memuat level yang terakhir kali disimpan
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1; // Melanjutkan waktu game

        Inventory playerInventory = FindObjectOfType<Inventory>();
        if (playerInventory != null)
        {
            playerInventory.LoadInventory();
        }
        // Setelah scene dimuat, Anda perlu menemukan karakter pemain dan mengatur posisi dan kesehatannya.
        // Ini bisa dilakukan melalui Start atau Awake method dalam script karakter pemain, atau menggunakan sistem event.
    }

    
}