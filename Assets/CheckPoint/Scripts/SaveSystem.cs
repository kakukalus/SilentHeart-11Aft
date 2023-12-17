using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    // Menyimpan data permainan ke PlayerPrefs.
    public static void SaveGameData(Vector3 checkpointPosition, float health, float sanity, int currentLevel)
    {
        // Menyimpan posisi checkpoint.
        PlayerPrefs.SetFloat("CheckpointX", checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
        PlayerPrefs.SetFloat("CheckpointZ", checkpointPosition.z);

        // Menyimpan kesehatan dan sanity pemain.
        PlayerPrefs.SetFloat("PlayerHealth", health);
        PlayerPrefs.SetFloat("PlayerSanity", sanity);

        // Menyimpan level saat ini.
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);

        // Menulis semua data yang dimodifikasi ke disk.
        PlayerPrefs.Save();
    }

    // Memuat posisi checkpoint dari PlayerPrefs.
    public static Vector3 LoadCheckpointPosition()
    {
        float x = PlayerPrefs.GetFloat("CheckpointX");
        float y = PlayerPrefs.GetFloat("CheckpointY");
        float z = PlayerPrefs.GetFloat("CheckpointZ");
        return new Vector3(x, y, z); // Mengembalikan posisi checkpoint.
    }

    // Memuat kesehatan pemain dari PlayerPrefs.
    public static float LoadPlayerHealth()
    {
        return PlayerPrefs.GetFloat("PlayerHealth", 100f); // Kembali ke kesehatan default jika tidak ditemukan.
    }

    // Memuat sanity pemain dari PlayerPrefs.
    public static float LoadPlayerSanity()
    {
        return PlayerPrefs.GetFloat("PlayerSanity", 100f); // Kembali ke sanity default jika tidak ditemukan.
    }

    // Memuat level saat ini dari PlayerPrefs.
    public static int LoadCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex); // Kembali ke level scene aktif jika tidak ditemukan.
    }

    // Menyimpan data inventori pemain ke PlayerPrefs.
    public static void SaveInventory(Inventory inventory)
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (!inventory.slots[i].IsEmpty)
            {
                // Menyimpan nama item pada slot inventori jika slot tidak kosong.
                PlayerPrefs.SetString($"InventorySlot{i}", inventory.slots[i].AssignedItem.itemName);
            }
            else
            {
                // Menghapus data slot inventori jika kosong.
                PlayerPrefs.DeleteKey($"InventorySlot{i}");
            }
        }
        // Menulis semua data yang dimodifikasi ke disk.
        PlayerPrefs.Save();
    }
}
