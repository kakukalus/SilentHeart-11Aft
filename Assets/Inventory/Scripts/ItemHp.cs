using UnityEngine;

public class ItemHP : Item
{
    // Jumlah peningkatan HP
    public float hpIncrease = 10f;

    // Dipanggil saat objek dibuat
    void Awake()
    {
        // Cari GameObject dengan tag "Player" dan tetapkan ke variabel player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Dipanggil saat objek diaktifkan
    void Start() 
    {
        // Dengan asumsi GameObject pemain Anda ditandai dengan "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Metode penggunaan item HP
    public override void Use()
    {
        // Dapatkan referensi ke kesehatan pemain
        MainCharacterHealth health = player.GetComponent<MainCharacterHealth>();

        // Periksa jika HP saat ini kurang dari maksimum sebelum menggunakan item
        if (health.GetCurrentHealth() < health.maxHealth)
        {
            Debug.Log("ItemHP Used");
            base.Use(); // Panggil base Use() jika diperlukan
            health.Heal(hpIncrease); // Panggil fungsi Heal untuk meningkatkan HP

        }
        else
        {
            Debug.Log("Health is full. ItemHP will not be used.");
            // Anda juga mungkin ingin memberikan umpan balik kepada pemain bahwa HP sudah penuh
        }
    }
}
