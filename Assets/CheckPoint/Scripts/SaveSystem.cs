using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    public static void SaveGameData(Vector3 checkpointPosition, float health, int currentLevel)
    {
        PlayerPrefs.SetFloat("CheckpointX", checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
        PlayerPrefs.SetFloat("CheckpointZ", checkpointPosition.z);
        PlayerPrefs.SetFloat("PlayerHealth", health);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
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
}
