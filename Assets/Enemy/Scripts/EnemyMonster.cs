using UnityEngine;

public class EnemyMonster : MonoBehaviour
{
    public Transform player; // Referensi ke transformasi pemain
    public GameObject enemyPrefab; // Prefab untuk musuh yang akan di-respawn
    public float spawnDistance = 5f; // Jarak spawn dari pemain
    public Vector2 spawnOffset = new Vector2(0f, 0f); // Offset untuk posisi spawn

    private MainCharacterSanity mainCharacterSanity; // Referensi ke skrip sanity pemain
    private GameObject currentEnemy; // Referensi ke musuh saat ini

    private void Start()
    {
        mainCharacterSanity = player.GetComponent<MainCharacterSanity>();
    }

    private void Update()
    {
        if (mainCharacterSanity.GetCurrentSanity() <= 10)
        {
            if (currentEnemy == null) // Hanya spawn jika belum ada musuh
            {
                RespawnEnemy();
            }
        }
        else if (mainCharacterSanity.GetCurrentSanity() > 10 && currentEnemy != null)
        {
            DestroyEnemy();
        }
    }

    private void RespawnEnemy()
    {
        MainCharacterController mainCharacterController = player.GetComponent<MainCharacterController>();
        if (mainCharacterController != null)
        {
            float direction = mainCharacterController.lastDirection;
            Vector3 spawnPosition = new Vector3(
                player.position.x + (spawnDistance * direction) + spawnOffset.x, 
                player.position.y + spawnOffset.y, 
                player.position.z
            );

            currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("MainCharacterController not found on the player!");
        }
    }

    private void DestroyEnemy()
    {
        Destroy(currentEnemy);
        currentEnemy = null;
    }
}
