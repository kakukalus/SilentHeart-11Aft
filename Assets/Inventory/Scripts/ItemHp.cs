using UnityEngine;

public class ItemHP : Item
{
    public float hpIncrease = 15f;
    // Jumlah HP yang akan ditambahkan ketika item digunakan.

    void Start()
    {
        // Saat objek diaktifkan, lakukan pencarian transform pemain sekali lagi.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Override metode penggunaan dari kelas Item.
    public override void Use()
    {
        MainCharacterHealth health = player.GetComponent<MainCharacterHealth>();
        if (health.currentHealth < health.maxHealth) // Cek jika HP pemain belum penuh.
        {
            base.Use(); // Panggil implementasi dasar 'Use', jika ada.
            health.Heal(hpIncrease); // Tambahkan HP ke pemain.
            Debug.Log("ItemHP Used"); // Log penggunaan item HP.
        }
        else
        {
            Debug.Log("Health is full. ItemHP will not be used."); // Log jika HP pemain sudah penuh.
        }
    }


}
