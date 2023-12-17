using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    private GameObject currentGhost;
    private bool isGhostSpawned = false;
    private float respawnTimer = 12f;
    private BoxCollider2D spawnArea; // Tambahkan Collider2D untuk menentukan area spawn

    void Start()
    {
        spawnArea = gameObject.GetComponent<BoxCollider2D>();
        // Memanggil metode SpawnGhost pada awal permainan
        SpawnGhost();
    }

    void Update()
    {
        // Cek apakah ghost sudah di-spawn
        if (currentGhost == null)
        {
            // Jika ghost di-destroy, atur timer untuk spawn ghost berikutnya
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                // Reset timer dan spawn ghost baru
                respawnTimer = 12f;
                SpawnGhost();
            }
        }
    }

    void SpawnGhost()
    {
        // Mengecek apakah spawnArea telah diatur
        if (spawnArea == null)
        {
            Debug.LogError("Spawn area collider not set!");
            return;
        }

        // Mendapatkan batasan spawnArea
        Bounds bounds = spawnArea.bounds;

        // Menghasilkan posisi acak dalam batasan spawnArea
        Vector2 randomSpawnPoint = new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );

        // Membuat instance baru dari ghostPrefab pada posisi acak yang dihasilkan
        currentGhost = Instantiate(ghostPrefab, randomSpawnPoint, Quaternion.identity);
        isGhostSpawned = true;
    }
}
