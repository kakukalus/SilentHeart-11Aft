using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 LastCheckpointPosition;
    public static float LastCheckpointHealth; // Menyimpan HP pemain saat checkpoint terakhir
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
        MainCharacterHealth playerHealth = FindObjectOfType<MainCharacterHealth>();
        if (playerHealth != null)
        {
            LastCheckpointHealth = playerHealth.GetCurrentHealth();
        }

        SaveSystem.SaveGameData(transform.position, LastCheckpointHealth, SceneManager.GetActiveScene().buildIndex);

    }
}
