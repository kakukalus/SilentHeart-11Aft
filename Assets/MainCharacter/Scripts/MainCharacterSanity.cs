using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainCharacterSanity : MonoBehaviour
{
    public float maxSanity = 100;
    private Animator baseCharacterAnimator;
    public Image MainCharacterHpBar; // Referensi ke UI Image untuk Sanity bar
    private float currentSanity;  // Nilai sanity saat ini
    public float sanityRegenAmount = 2f; // Jumlah sanity yang diregenerasi per detik
    public float regenSanityDelay = 3f; // Waktu tunda sebelum memulai regenerasi sanity
    private float lastDamageTime; // Waktu saat terakhir kali menerima damage

    private void Start()
    {
        baseCharacterAnimator = GetComponentInChildren<Animator>();
        // Muat nilai sanity yang tersimpan atau gunakan maxSanity jika belum ada yang tersimpan
              currentSanity = SaveSystem.LoadPlayerSanity();
        SetMainCharacterBar(currentSanity);
        baseCharacterAnimator.SetBool("isAlive", true);
        StartCoroutine(RegenerateSanity());


    }


    private void Die()
    {
        // Logika kematian karakter
        Debug.Log("MainCharacter has died!");
    }

    public void SetMainCharacterBar(float sanity)
    {
        sanity = Mathf.Clamp(sanity, 0f, maxSanity);
        MainCharacterHpBar.fillAmount = sanity / maxSanity;
    }

    public void LoseSanity(float damage)
    {
        currentSanity -= damage;
        currentSanity = Mathf.Max(0f, currentSanity);
        SetMainCharacterBar(currentSanity);
        lastDamageTime = Time.time; // Memperbarui waktu terakhir menerima damage
    }

    private IEnumerator RegenerateSanity()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // Tunggu 1 detik
            if (Time.time >= lastDamageTime + regenSanityDelay)
            {
                // Regenerasi sanity jika waktu terakhir damage + delay <= waktu sekarang
                GainSanity(sanityRegenAmount);
            }
        }
    }

    public void GainSanity(float amount)
    {
        if (currentSanity < maxSanity)
        {
            currentSanity += amount;
            currentSanity = Mathf.Min(currentSanity, maxSanity); // Pastikan sanity tidak melebihi maxSanity
            SetMainCharacterBar(currentSanity);
        }
    }

    public float GetCurrentSanity()
    {
        return currentSanity;
    }

    public void SetSanity(float sanityValue)
    {
        currentSanity = sanityValue;
        SetMainCharacterBar(currentSanity);
    }

    //     private void OnDisable()
    // {
    //     SaveSanity(); // Simpan nilai sanity saat script dinonaktifkan atau sebelum scene berubah
    // }

    // public void SaveSanity()
    // {
    //     PlayerPrefs.SetFloat("PlayerSanity", currentSanity); // Simpan nilai sanity saat ini
    //     PlayerPrefs.Save(); // Pastikan untuk menyimpan perubahan ke PlayerPrefs
    // }

    // public void LoadSanity()
    // {
    //     currentSanity = PlayerPrefs.GetFloat("PlayerSanity", maxSanity); // Muat nilai sanity yang tersimpan atau gunakan maxSanity jika belum ada yang tersimpan
    //     SetMainCharacterBar(currentSanity); // Perbarui bar sanity di UI
    // }
}