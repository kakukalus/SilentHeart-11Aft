using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCharacterSanity : MonoBehaviour
{
    public float maxSanity = 100; // Nilai maksimum sanity yang bisa dimiliki karakter.
    private Animator baseCharacterAnimator; // Animator untuk karakter utama.
    public Image MainCharacterHpBar; // UI Image untuk menampilkan bar sanity.
    private float currentSanity;  // Nilai sanity saat ini dari karakter.
    public float sanityRegenAmount = 2f; // Jumlah sanity yang diregenerasi per detik.
    public float regenSanityDelay = 3f; // Waktu tunda sebelum memulai regenerasi sanity.
    private float lastDamageTime; // Waktu saat terakhir kali menerima damage.

    private void Start()
    {
        baseCharacterAnimator = GetComponentInChildren<Animator>();
        currentSanity = SaveSystem.LoadPlayerSanity(); // Muat nilai sanity yang tersimpan atau gunakan maxSanity jika belum ada yang tersimpan.
        SetMainCharacterBar(currentSanity);
        baseCharacterAnimator.SetBool("isAlive", true);
        StartCoroutine(RegenerateSanity()); // Memulai coroutine untuk regenerasi sanity secara otomatis.
    }

    private void Die()
    {
        // Logika kematian karakter. Ini dapat diisi dengan aksi yang diinginkan saat karakter mati.
        Debug.Log("MainCharacter has died!");
    }

    public void SetMainCharacterBar(float sanity)
    {
        // Mengatur UI sanity bar sesuai dengan nilai sanity saat ini.
        sanity = Mathf.Clamp(sanity, 0f, maxSanity);
        MainCharacterHpBar.fillAmount = sanity / maxSanity;
    }

    public void LoseSanity(float damage)
    {
        // Mengurangi nilai sanity karakter ketika menerima damage.
        currentSanity -= damage;
        currentSanity = Mathf.Max(0f, currentSanity); // Pastikan sanity tidak turun di bawah 0.
        SetMainCharacterBar(currentSanity);
        lastDamageTime = Time.time; // Memperbarui waktu terakhir menerima damage.
    }

    private IEnumerator RegenerateSanity()
    {
        // Coroutine untuk regenerasi sanity.
        while (true)
        {
            yield return new WaitForSeconds(1f); // Tunggu 1 detik antara setiap iterasi.
            if (Time.time >= lastDamageTime + regenSanityDelay)
            {
                // Jika sudah melewati delay setelah menerima damage, regenerasi sanity.
                GainSanity(sanityRegenAmount);
            }
        }
    }

    public void GainSanity(float amount)
    {
        // Menambah nilai sanity.
        if (currentSanity < maxSanity)
        {
            currentSanity += amount;
            currentSanity = Mathf.Min(currentSanity, maxSanity); // Pastikan sanity tidak melebihi batas maksimum.
            SetMainCharacterBar(currentSanity);
        }
    }

    public float GetCurrentSanity()
    {
        // Mendapatkan nilai sanity saat ini.
        return currentSanity;
    }

    public void SetSanity(float sanityValue)
    {
        // Mengatur nilai sanity secara langsung.
        currentSanity = sanityValue;
        SetMainCharacterBar(currentSanity);
    }
}
