using UnityEngine;

public class ItemSesajen : Item
{
    public GameObject pocong; // Assign objek pocong di inspector
    public bool HasBeenUsedSuccessfully { get; private set; }
    public float jarakPenggunaan = 1.5f; // Jarak dimana pemain harus berada dekat dengan pohon untuk menggunakan item

    // Kita asumsikan hanya ada satu objek pohon di scene untuk kesederhanaan
    private GameObject pohon;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pohon = GameObject.FindGameObjectWithTag("Tree");
    }

    public override void Use()
    {
        // Periksa jika pemain cukup dekat dengan pohon untuk menggunakan item
        if(Vector3.Distance(player.position, pohon.transform.position) <= jarakPenggunaan)
        {
            // Periksa jika pocong aktif di scene
            if(pocong != null && pocong.activeInHierarchy)
            {
                Debug.Log("ItemSesajen Digunakan");
                // Panggil base Use() jika diperlukan
                base.Use();
                // Hancurkan objek pocong
                Destroy(pocong);

                HasBeenUsedSuccessfully = true;

                // Berikan feedback ke pemain
                Debug.Log("Pocong telah diusir!");
            }
            else
            {
                Debug.Log("Tidak ada Pocong yang bisa diusir.");
            }
        }
        else
        {
            // Jangan hancurkan item dan berikan feedback ke pemain
            Debug.Log("Anda harus lebih dekat ke pohon untuk menggunakan Sesajen.");
        }
    }

}
