using UnityEngine;

public class EnemyMonster : MonoBehaviour
{
    public Transform player; // Referensi ke transform pemain, digunakan untuk menentukan lokasi pemain dalam scene.
    public GameObject enemyPrefab; // Prefab musuh yang akan digunakan untuk spawning.
    public float spawnDistance = 5f; // Jarak dari pemain di mana musuh akan di-spawn.
    public Vector2 spawnOffset = new Vector2(0f, 0f); // Offset tambahan untuk posisi spawn, untuk penyesuaian halus.

    private MainCharacterSanity mainCharacterSanity; // Referensi ke komponen sanity (kewarasan) dari pemain.
    private GameObject currentEnemy; // Objek musuh yang saat ini aktif di scene.

    private void Start()
    {
        // Mendapatkan komponen sanity dari pemain saat awal game dimulai.
        mainCharacterSanity = player.GetComponent<MainCharacterSanity>();
    }

    private void Update()
    {
        // Cek apakah sanity pemain turun di bawah ambang batas tertentu.
        if (mainCharacterSanity.GetCurrentSanity() <= 10)
        {
            if (currentEnemy == null) // Jika tidak ada musuh aktif, spawn musuh baru.
            {
                RespawnEnemy();
            }
        }
        else if (mainCharacterSanity.GetCurrentSanity() > 10 && currentEnemy != null)
        {
            // Jika sanity pemain di atas ambang batas dan ada musuh, hancurkan musuh tersebut.
            DestroyEnemy();
        }
    }

    private void RespawnEnemy()
    {
        // Mendapatkan komponen controller dari pemain untuk menentukan arah terakhir pemain.
        MainCharacterController mainCharacterController = player.GetComponent<MainCharacterController>();
        if (mainCharacterController != null)
        {
            // Hitung arah spawn berdasarkan arah terakhir pemain.
            float direction = mainCharacterController.lastDirection;
            Vector3 spawnPosition = new Vector3(
                player.position.x + (spawnDistance * direction) + spawnOffset.x, 
                player.position.y + spawnOffset.y, 
                player.position.z
            );

            // Membuat instance musuh baru pada posisi yang dihitung.
            currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            // Tampilkan pesan error jika komponen controller tidak ditemukan pada pemain.
            Debug.LogError("MainCharacterController not found on the player!");
        }
    }

    private void DestroyEnemy()
    {
        // Menghancurkan objek musuh dan setel referensi currentEnemy menjadi null.
        Destroy(currentEnemy);
        currentEnemy = null;
    }
}
