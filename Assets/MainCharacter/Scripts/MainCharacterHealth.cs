using UnityEngine;
using UnityEngine.UI;

public class MainCharacterHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private Animator baseCharacterAnimator;
    public Image MainCharacterHpBar; // Referensi ke UI Image untuk health bar
    public float currentHealth = 100f;  // Nilai hp saat ini

    private GameManager gameManager;
    private void Start()
    {
        MainCharacterHpBar = GameObject.Find("Canvas/HealthBar/HealthBar Fill").GetComponent<Image>();
        gameManager = GameObject.FindGameObjectWithTag("Player").GetComponent<GameManager>();
        baseCharacterAnimator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;
        baseCharacterAnimator.SetBool("isAlive", true);
    }

    // Mengatur fillAmount berdasarkan nilai hp dalam rentang 0-100
    public void SetMainCharacterBar(float hp)
    {
        // Memastikan nilai hp berada dalam rentang yang valid (0-100)
        hp = Mathf.Clamp(hp, 0f, 100f);
        // Menetapkan fillAmount pada health bar berdasarkan nilai hp yang valid
        MainCharacterHpBar.fillAmount = hp / 100f;
    }

    // Metode untuk mengurangkan Hp pemain
    public void TakeDamage(float damage)
    {
        // Mengurangkan nilai hp pemain berdasarkan jumlah kerusakan
        currentHealth -= damage;
        // Memastikan nilai hp tidak kurang dari 0
        currentHealth = Mathf.Max(0f, currentHealth);
        // Memperbarui health bar setelah menerima kerusakan
        SetMainCharacterBar(currentHealth);
    }


}
