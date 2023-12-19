using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        // Memuat data dari PlayerPrefs untuk posisi checkpoint, kesehatan pemain, dan level saat ini.
        Vector3 checkpointPosition = SaveSystem.LoadCheckpointPosition();
        float playerHealth = SaveSystem.LoadPlayerHealth();
        int currentLevel = SaveSystem.LoadCurrentLevel();

        // Memuat level yang terakhir kali disimpan.
        SceneManager.LoadScene(currentLevel);
        Time.timeScale = 1; // Mengatur waktu game kembali ke normal (melanjutkan permainan jika sebelumnya dipause).

        // Setelah scene dimuat, perlu menemukan objek Inventory pemain dan memuat data inventori.
        Inventory playerInventory = FindObjectOfType<Inventory>();
        if (playerInventory != null)
        {
            playerInventory.LoadInventory();
        }
<<<<<<< HEAD
    }
=======

         // Load dialog triggers status
        DialogTrigger[] allDialogTriggers = FindObjectsOfType<DialogTrigger>();
        SaveSystem.LoadAllDialogTriggers(allDialogTriggers);
        
    }

    
>>>>>>> 5cb07d58ed10ca197af2fd8ed82831edd9d6d5c4
}
