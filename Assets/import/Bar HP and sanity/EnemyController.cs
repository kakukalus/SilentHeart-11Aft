// Skrip ini mengontrol perilaku musuh ketika bersentuhan dengan pemain.
// Memberikan damage pada kesehatan dan kehilangan sanity pada pemain saat bersentuhan.

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Menyimpan referensi ke PlayerHp untuk menghindari panggilan GetComponent berulang
    private PlayerHp playerHp;
    private PlayerSanity playerSanity;

    // Damage yang akan diberikan pada pemain saat bersentuhan
    public float damageOnHit = 50f;
    public float sanityLossOnHit = 50f;

    // Dipanggil saat skrip dimulai
    void Start()
    {
        // Mendapatkan referensi PlayerHp saat inisialisasi
        playerHp = FindObjectOfType<PlayerHp>();

        // Mendapatkan referensi PlayerSanity saat inisialisasi
        playerSanity = FindObjectOfType<PlayerSanity>();
    }

    // Dipanggil saat objek ini bersentuhan dengan objek lain
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Memastikan objek yang bersentuhan adalah pemain
        if (collision.gameObject.CompareTag("Player"))
        {
            // Memeriksa apakah referensi playerHp tidak kosong
            if (playerHp != null)
            {
                // Menyampaikan damage ke PlayerHp
                playerHp.TakeDamage(damageOnHit);

                // Menyampaikan sanityLoss ke PlayerSanity
                playerSanity.LoseSanity(sanityLossOnHit);
            }
            else
            {
            }
        }
    }
}
