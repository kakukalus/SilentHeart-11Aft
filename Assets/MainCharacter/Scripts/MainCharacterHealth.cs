using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacterHealth : MonoBehaviour
{
    public float maxHealth = 100; // Nilai maksimum kesehatan yang bisa dimiliki karakter.
    private Animator baseCharacterAnimator; // Animator untuk karakter utama.
    public Image MainCharacterHpBar; // UI Image untuk menampilkan health bar.
    private float currentHealth = 100f;  // Nilai kesehatan saat ini dari karakter.

    private void Start()
    {
        baseCharacterAnimator = GetComponentInChildren<Animator>();
        if (SceneManager.GetActiveScene().buildIndex == SaveSystem.LoadCurrentLevel())
        {
            // Jika scene saat ini sama dengan level yang disimpan, muat posisi dan kesehatan dari save data.
            transform.position = SaveSystem.LoadCheckpointPosition();
            currentHealth = SaveSystem.LoadPlayerHealth();
        }
        else
        {
            // Jika bukan, gunakan nilai kesehatan maksimum.
            currentHealth = maxHealth;
        }
        SetMainCharacterBar(currentHealth); // Atur UI health bar.
        baseCharacterAnimator.SetBool("isAlive", true);
    }

    public void RespawnAtLastCheckpoint()
    {
        // Logika respawn karakter di checkpoint terakhir.
        if (Checkpoint.LastCheckpointPosition != null)
        {
            transform.position = Checkpoint.LastCheckpointPosition; // Pindahkan karakter ke posisi checkpoint terakhir.
            currentHealth = Checkpoint.LastCheckpointHealth; // Setel kesehatan ke nilai saat checkpoint terakhir.
            SetMainCharacterBar(currentHealth);

            // Juga setel sanity karakter jika perlu.
            MainCharacterSanity playerSanity = GetComponent<MainCharacterSanity>();
            if (playerSanity != null)
            {
                float lastSanity = SaveSystem.LoadPlayerSanity();
                playerSanity.SetSanity(lastSanity);
            }

            // Opsional: Tambahkan efek atau animasi saat respawn.
        }
    }

    private void Die()
    {
        // Logika kematian karakter.
        Debug.Log("MainCharacter has died!");

        // Temukan RespawnManager dan tampilkan panel respawn.
        FindObjectOfType<RespawnManager>().ShowRespawnPanel();

        // Opsional: Pause permainan jika diperlukan.
        Time.timeScale = 0f;
    }

    public void SetMainCharacterBar(float hp)
    {
        // Mengatur UI health bar sesuai dengan nilai kesehatan saat ini.
        hp = Mathf.Clamp(hp, 0f, 100f);
        MainCharacterHpBar.fillAmount = hp / 100f;
    }

    public void TakeDamage(float damage)
    {
        // Mengurangi nilai kesehatan karakter ketika menerima damage.
        currentHealth -= damage;
        currentHealth = Mathf.Max(0f, currentHealth);
        SetMainCharacterBar(currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Memanggil metode Die ketika kesehatan habis.
        }
    }

    public float GetCurrentHealth()
    {
        // Mendapatkan nilai kesehatan saat ini.
        return currentHealth;
    }

    public void Heal(float healAmount)
    {
        // Menambah nilai kesehatan.
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Pastikan kesehatan tidak melebihi batas maksimum.
        SetMainCharacterBar(currentHealth); // Atur UI health bar.
    }
}
