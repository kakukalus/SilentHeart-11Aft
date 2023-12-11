using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
public static void SaveGameData(Vector3 checkpointPosition, float checkpointHealth, float checkpointSanity, int sceneIndex)
    {
        PlayerPrefs.SetFloat("CheckpointX", checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
        PlayerPrefs.SetFloat("CheckpointZ", checkpointPosition.z);
        
        PlayerPrefs.SetFloat("CheckpointHealth", checkpointHealth);
        PlayerPrefs.SetFloat("CheckpointSanity", checkpointSanity);

        // Menyimpan indeks scene
        PlayerPrefs.SetInt("SceneIndex", sceneIndex);

        PlayerPrefs.Save();
    }
    public static Vector3 LoadCheckpointPosition()
    {
        float x = PlayerPrefs.GetFloat("CheckpointX");
        float y = PlayerPrefs.GetFloat("CheckpointY");
        float z = PlayerPrefs.GetFloat("CheckpointZ");
        return new Vector3(x, y, z);
    }

    public static float LoadPlayerHealth()
    {
        return PlayerPrefs.GetFloat("PlayerHealth", 100f); // Return default health if not found
    }

    public static int LoadCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex); // Return current scene if not found
    }

    public static void SaveInventory(Inventory inventory)
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (!inventory.slots[i].IsEmpty)
            {
                PlayerPrefs.SetString($"InventorySlot{i}", inventory.slots[i].AssignedItem.itemName);
            }
            else
            {
                PlayerPrefs.DeleteKey($"InventorySlot{i}");
            }
        }
        PlayerPrefs.Save();
    }
}
