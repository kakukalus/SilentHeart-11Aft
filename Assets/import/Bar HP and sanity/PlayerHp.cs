// Skrip ini mengelola kesehatan pemain, termasuk tampilan health bar di UI.

using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Image playerHpBar; // Referensi ke UI Image untuk health bar
    private float currentHealth = 100f;  // Nilai hp saat ini

    // Mengatur fillAmount berdasarkan nilai hp dalam rentang 0-100
    public void SetPlayerBar(float hp)
    {
        // Memastikan nilai hp berada dalam rentang yang valid (0-100)
        hp = Mathf.Clamp(hp, 0f, 100f);

        // Menetapkan fillAmount pada health bar berdasarkan nilai hp yang valid
        playerHpBar.fillAmount = hp / 100f;
    }

    // Metode untuk mengurangkan Hp pemain
    public void TakeDamage(float damage)
    {
        // Mengurangkan nilai hp pemain berdasarkan jumlah kerusakan
        currentHealth -= damage;

        // Memastikan nilai hp tidak kurang dari 0
        currentHealth = Mathf.Max(0f, currentHealth);

        // Memperbarui health bar setelah menerima kerusakan
        SetPlayerBar(currentHealth);
    }

    // Metode untuk mendapatkan nilai hp saat ini
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
