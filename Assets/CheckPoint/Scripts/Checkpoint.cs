using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 LastCheckpointPosition; // Menyimpan posisi checkpoint terakhir.
    public static float LastCheckpointHealth; // Menyimpan kesehatan pemain saat checkpoint terakhir.
    public static float LastCheckpointSanity; // Menyimpan sanity pemain saat checkpoint terakhir.
    public Sprite lampOn; // Sprite untuk lampu saat checkpoint diaktifkan.
    public Light2D checkpointLight; // Komponen pencahayaan untuk checkpoint.
    public ParticleSystem particles; // Sistem partikel untuk efek visual pada checkpoint.
    private bool isActivated = false; // Status aktivasi checkpoint.

    void Start()
    {
        // Nonaktifkan pencahayaan dan partikel di awal.
        checkpointLight.enabled = false;
        particles.Stop();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Aktifkan checkpoint ketika pemain memasuki trigger.
        if (other.CompareTag("Player") && !isActivated)
        {
            ActivateCheckpoint();
        }
    }

    void ActivateCheckpoint()
    {
        // Ganti sprite dan aktifkan pencahayaan dan partikel.
        GetComponent<SpriteRenderer>().sprite = lampOn;
        checkpointLight.enabled = true;
        particles.Play();
        isActivated = true;
        LastCheckpointPosition = transform.position; // Simpan posisi checkpoint saat ini.

        // Menyimpan kesehatan dan sanity pemain saat ini.
        MainCharacterSanity playerSanity = FindObjectOfType<MainCharacterSanity>();
        MainCharacterHealth playerHealth = FindObjectOfType<MainCharacterHealth>();
        if (playerHealth != null)
        {
            LastCheckpointHealth = playerHealth.GetCurrentHealth();
        }
        if (playerSanity != null)
        {
            LastCheckpointSanity = playerSanity.GetCurrentSanity();
            SaveSystem.SaveGameData(transform.position, LastCheckpointHealth, LastCheckpointSanity, SceneManager.GetActiveScene().buildIndex);
        }

        // Menyimpan data inventori pemain.
        Inventory playerInventory = FindObjectOfType<Inventory>();
        if (playerInventory != null)
        {
            SaveSystem.SaveInventory(playerInventory);
        }
    }
}
