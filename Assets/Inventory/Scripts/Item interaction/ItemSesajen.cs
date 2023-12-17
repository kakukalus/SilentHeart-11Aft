using UnityEngine;

public class ItemSesajen : Item
{
    public GameObject pocong; // Objek pocong yang harus diusir dengan item ini.
    public bool HasBeenUsedSuccessfully { get; private set; } // Status apakah item telah berhasil digunakan.
    public float jarakPenggunaan = 1.5f; // Jarak maksimum dari pemain ke pohon untuk menggunakan item.

    private GameObject pohon; // Referensi ke objek pohon dalam game.

    void Awake()
    {
        // Inisialisasi referensi transform pemain dan pohon saat objek dibuat.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pohon = GameObject.FindGameObjectWithTag("Tree");
    }

    // Override metode Use dari kelas Item.
    public override void Use()
    {
        // Cek apakah pemain cukup dekat dengan pohon untuk menggunakan item.
        if(Vector3.Distance(player.position, pohon.transform.position) <= jarakPenggunaan)
        {
            // Cek apakah objek pocong aktif dalam scene.
            if(pocong != null && pocong.activeInHierarchy)
            {
                base.Use(); // Panggil implementasi dasar 'Use', jika ada.
                Destroy(pocong); // Hancurkan objek pocong.
                HasBeenUsedSuccessfully = true; // Tandai item sebagai berhasil digunakan.
                Debug.Log("Pocong telah diusir!"); // Log pesan berhasil.
            }
            else
            {
                Debug.Log("Tidak ada Pocong yang bisa diusir."); // Log jika tidak ada pocong di scene.
            }
        }
        else
        {
            // Log jika pemain tidak cukup dekat dengan pohon.
            Debug.Log("Anda harus lebih dekat ke pohon untuk menggunakan Sesajen.");
        }
    }
}
