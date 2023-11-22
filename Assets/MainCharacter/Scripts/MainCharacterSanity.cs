using UnityEngine;
using UnityEngine.UI;

public class MainCharacterSanity : MonoBehaviour
{
    public float maxSanity = 100;
    private Animator baseCharacterAnimator;
    public Image MainCharacterHpBar; // Referensi ke UI Image untuk Sanity bar
    private float currentSanity = 100f;  // Nilai hp saat ini
    private void Start()
    {
        baseCharacterAnimator = GetComponentInChildren<Animator>();
        currentSanity = maxSanity;
        baseCharacterAnimator.SetBool("isAlive", true);
    }

    public void TakeDamage(int damageAmount)
    {
        currentSanity -= damageAmount;

        if (currentSanity <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Logika kematian karakter, seperti memunculkan layar kekalahan atau mereset level
        Debug.Log("MainCharacter has died!");
    }

    // Mengatur fillAmount berdasarkan nilai hp dalam rentang 0-100
    public void SetMainCharacterBar(float hp)
    {
        // Memastikan nilai hp berada dalam rentang yang valid (0-100)
        hp = Mathf.Clamp(hp, 0f, 100f);
        // Menetapkan fillAmount pada Sanity bar berdasarkan nilai hp yang valid
        MainCharacterHpBar.fillAmount = hp / 100f;
    }

    // Metode untuk mengurangkan Hp pemain
    public void TakeDamage(float damage)
    {
        // Mengurangkan nilai hp pemain berdasarkan jumlah kerusakan
        currentSanity -= damage;
        // Memastikan nilai hp tidak kurang dari 0
        currentSanity = Mathf.Max(0f, currentSanity);
        // Memperbarui Sanity bar setelah menerima kerusakan
        SetMainCharacterBar(currentSanity);
    }

    // Metode untuk mendapatkan nilai hp saat ini
    public float GetCurrentSanity()
    {
        return currentSanity;
    }
}
