// Script ini mengontrol pergerakan dan perilaku karakter pemain.
// Menggunakan slider untuk mengatur kecepatan karakter dan mendele­gasikan perubahan kesehatan dan sanity ke skrip lain.

using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    // Referensi Slider untuk mengendalikan kecepatan karakter
    public Slider slider;

    // Kecepatan dasar dan maksimal karakter
    public float baseSpeed = 5f;
    public float maxSpeed = 10f;

    // Nilai awal slider
    private float originalValue = 0.5f;

    // Referensi skrip PlayerHp dan PlayerSanity untuk mengelola kesehatan dan sanity
    private PlayerHp playerHp;
    private PlayerSanity playerSanity;

    // Dipanggil saat skrip dimulai
    void Start()
    {
        // Dapatkan referensi skrip PlayerHp dan PlayerSanity
        playerHp = GetComponent<PlayerHp>();
        playerSanity = GetComponent<PlayerSanity>();

        // Atur nilai awal slider
        slider.value = originalValue;
    }

    // Dipanggil setiap frame
    void Update()
    {
        // Dapatkan kecepatan saat ini berdasarkan nilai slider
        float currentSpeed = CurrentSpeed();

        // Tambahkan logika pergerakan karakter di sini menggunakan currentSpeed
    }

    // Dipanggil saat karakter menerima damage
    void TakeDamage(float damage)
    {
        // Delegasikan penanganan perubahan kesehatan ke skrip PlayerHp
        playerHp.TakeDamage(damage);
    }

    // Dipanggil saat karakter kehilangan sanity
    void LoseSanity(float sanityLoss)
    {
        // Delegasikan penanganan perubahan sanity ke skrip PlayerSanity
        playerSanity.LoseSanity(sanityLoss);
    }

    // Hitung kecepatan saat ini berdasarkan nilai slider
    public float CurrentSpeed()
    {
        float currentValue = slider.value;

        // Hitung kecepatan saat ini berdasarkan nilai slider
        if (currentValue > originalValue)
        {
            // Interpolasi linier untuk mendapatkan nilai kecepatan antara baseSpeed dan maxSpeed
            return Mathf.Lerp(baseSpeed, maxSpeed, Mathf.Abs(currentValue - originalValue) * 2);
        }

        // Jika nilai slider tidak melebihi nilai awal, kembalikan kecepatan dasar
        return baseSpeed;
    }
}