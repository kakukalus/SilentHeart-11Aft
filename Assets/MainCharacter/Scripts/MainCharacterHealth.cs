using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainCharacterHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private Animator baseCharacterAnimator;
    public Image MainCharacterHpBar; // Referensi ke UI Image untuk health bar
    private float currentHealth = 100f;  // Nilai hp saat ini
    private void Start()
    {
        baseCharacterAnimator = GetComponentInChildren<Animator>();
        if (SceneManager.GetActiveScene().buildIndex == SaveSystem.LoadCurrentLevel())
        {
            // Posisi dan kesehatan pemain diatur ke nilai yang disimpan
            transform.position = SaveSystem.LoadCheckpointPosition();
            currentHealth = SaveSystem.LoadPlayerHealth();
        }
        else
        {
            currentHealth = maxHealth;
        }
        SetMainCharacterBar(currentHealth);
        baseCharacterAnimator.SetBool("isAlive", true);
    }


    public void RespawnAtLastCheckpoint()
    {
        if (Checkpoint.LastCheckpointPosition != null)
        {
            transform.position = Checkpoint.LastCheckpointPosition;
            currentHealth = Checkpoint.LastCheckpointHealth; // Set HP ke nilai saat checkpoint terakhir
            SetMainCharacterBar(currentHealth);
            // Anda bisa menambahkan animasi atau efek khusus saat respawn
        }
    }

    private void Die()
    {
        Debug.Log("MainCharacter has died!");

        // Temukan RespawnManager dan tampilkan panel respawn
        FindObjectOfType<RespawnManager>().ShowRespawnPanel();

        // Optional: Pause the game if needed
        Time.timeScale = 0f;
    }

    // Mengatur fillAmount berdasarkan nilai hp dalam rentang 0-100
    public void SetMainCharacterBar(float hp)
    {
        // Memastikan nilai hp berada dalam rentang yang valid (0-100)
        hp = Mathf.Clamp(hp, 0f, 100f);
        // Menetapkan fillAmount pada health bar berdasarkan nilai hp yang valid
        MainCharacterHpBar.fillAmount = hp / 100f;
    }

    // Metode TakeDamage diupdate untuk memanggil Die() jika HP habis
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0f, currentHealth);
        SetMainCharacterBar(currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Pemanggilan metode Die ketika HP habis
        }
    }

    // Metode untuk mendapatkan nilai hp saat ini
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

        public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure HP does not exceed maxHealth
        SetMainCharacterBar(currentHealth); // Update the UI
    }

}
