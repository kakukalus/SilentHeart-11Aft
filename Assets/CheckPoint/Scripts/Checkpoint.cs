using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 LastCheckpointPosition;
    public static float LastCheckpointHealth; // Menyimpan HP pemain saat checkpoint terakhir
    public static float LastCheckpointSanity; // Menyimpan Sanity pemain saat checkpoint terakhir
    public Sprite lampOn;
    public Light2D checkpointLight;
    public ParticleSystem particles;
    private bool isActivated = false;

    void Start()
    {
        checkpointLight.enabled = false;
        particles.Stop();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            ActivateCheckpoint();
        }
    }

    void ActivateCheckpoint()
    {
        GetComponent<SpriteRenderer>().sprite = lampOn;
        checkpointLight.enabled = true;
        particles.Play();
        isActivated = true;
        LastCheckpointPosition = transform.position;

        // Menyimpan HP pemain saat ini
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

        

        // Menyimpan data inventori
        Inventory playerInventory = FindObjectOfType<Inventory>();
        if (playerInventory != null)
        {
            SaveSystem.SaveInventory(playerInventory);
        }
    }
}