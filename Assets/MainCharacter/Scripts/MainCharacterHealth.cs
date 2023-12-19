using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacterHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private Animator baseCharacterAnimator;
    public Image MainCharacterHpBar; // Referensi ke UI Image untuk health bar
    public float currentHealth = 100f;  // Nilai hp saat ini

    public RespawnManager RespawnManager;
    private void Start()
    {
        MainCharacterHpBar = GameObject.Find("Canvas/HealthBar/HealthBar Fill").GetComponent<Image>();
        baseCharacterAnimator = GetComponentInChildren<Animator>();

        GameObject respawnManagerGameobject = GameObject.Find("GameManager");
        RespawnManager = respawnManagerGameobject.GetComponent<RespawnManager>();

        // if (SceneManager.GetActiveScene().buildIndex == SaveSystem.LoadCurrentLevel())
        // {
        //     // Jika scene saat ini sama dengan level yang disimpan, muat posisi dan kesehatan dari save data.
        //     transform.position = SaveSystem.LoadCheckpointPosition();
        //     currentHealth = SaveSystem.LoadPlayerHealth();
        // }
        // else
        // {
        //     // Jika bukan, gunakan nilai kesehatan maksimum.
        //     currentHealth = maxHealth;
        // }
        SetMainCharacterBar(currentHealth); // Atur UI health bar.
        baseCharacterAnimator.SetBool("isAlive", true);
    }

    private void Update()
    {

    }

    public void MainCharacterDead()
    {
        baseCharacterAnimator.SetBool("isAlive", false);
        baseCharacterAnimator.SetBool("isDead", true);
        RespawnManager.ShowRespawnPanel();
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

    }

    public void Heal(float heal)
    {
        // Mengurangi nilai kesehatan karakter ketika menerima damage.
        currentHealth += heal;
        currentHealth = Mathf.Max(0f, currentHealth);
        SetMainCharacterBar(currentHealth);

    }

}
