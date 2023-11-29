// Skrip ini mengelola sanity pemain, termasuk tampilan sanity bar di UI.

using UnityEngine;
using UnityEngine.UI;

public class PlayerSanity : MonoBehaviour
{
    public Image sanityBar;      // Referensi ke UI Image untuk sanity bar
    private float currentSanity = 100f;  // Nilai sanity saat ini

    // Mengatur fillAmount berdasarkan nilai sanity dalam rentang 0-100
    public void SetSanityBar(float sanity)
    {
        // Memastikan nilai sanity berada dalam rentang yang valid (0-100)
        sanity = Mathf.Clamp(sanity, 0f, 100f);

        // Menetapkan fillAmount pada sanity bar berdasarkan nilai sanity yang valid
        sanityBar.fillAmount = sanity / 100f;
    }

    // Metode untuk mengurangkan Sanity pemain
    public void LoseSanity(float sanityLoss)
    {
        // Mengurangkan nilai sanity pemain berdasarkan jumlah kehilangan sanity
        currentSanity -= sanityLoss;

        // Memastikan nilai sanity tidak kurang dari 0
        currentSanity = Mathf.Max(0f, currentSanity);

        // Memperbarui sanity bar setelah kehilangan sanity
        SetSanityBar(currentSanity);
    }

    // Metode untuk mendapatkan nilai sanity saat ini
    public float GetCurrentSanity()
    {
        return currentSanity;
    }
}
