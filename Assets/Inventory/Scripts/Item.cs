using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // Nama dari item, digunakan untuk identifikasi.
    public PickButton pickButton; // Referensi ke tombol ambil yang terkait dengan item ini.
    public Transform player; // Referensi ke transform pemain, digunakan untuk interaksi.

    private bool isPickedUp = false; // Status yang menandakan apakah item telah diambil.

    // Metode virtual ini bisa dioverride oleh subclass untuk menentukan aksi ketika item digunakan.
    public virtual void Use()
    {
        Debug.Log("Base Item Used");
    }

    // Trigger ketika pemain mendekati item.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Cek apakah collider yang bersentuhan adalah pemain.
        {
            Inventory playerInventory = other.GetComponent<Inventory>();
            if (pickButton != null && playerInventory != null)
            {
                pickButton.EnableButton(); // Aktifkan tombol ambil jika kondisi terpenuhi.
                pickButton.Initialize(this, playerInventory); // Inisialisasi tombol dengan item ini.
            }
            other.GetComponent<Inventory>().TargetItem(this); // Tetapkan item ini sebagai target di inventori pemain.
        }
    }

    // Trigger ketika pemain menjauh dari item.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickButton != null)
            {
                pickButton.DisableButton(); // Nonaktifkan tombol ambil.
            }
            other.GetComponent<Inventory>().UntargetItem(this); // Hapus item ini dari target di inventori pemain.
        }
    }

    // Fungsi untuk mengambil item.
    public void PickUp()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
            gameObject.SetActive(false); // Nonaktifkan game object item ini (menghilangkan dari scene).
            if (pickButton != null)
            {
                pickButton.DisableButton(); // Nonaktifkan tombol ambil setelah item diambil.
            }
            Debug.Log($"Picked up {itemName}."); // Log pesan pengambilan.
        }
    }

    // Fungsi untuk melepaskan item.
    public void Drop()
    {
        gameObject.SetActive(true); // Aktifkan kembali game object item ini di scene.
        transform.position = CalculateDropPosition(); // Posisikan item dekat pemain.
    }

    // Fungsi untuk menghitung posisi item ketika dijatuhkan.
    private Vector3 CalculateDropPosition()
    {
        if (player != null)
        {
            // Tempatkan item sedikit di atas posisi pemain.
            return new Vector3(player.position.x, player.position.y + 0.3f, player.position.z);
        }
        else
        {
            Debug.LogError("Player transform is null. Make sure to assign it in the inspector.");
            return Vector3.zero; // Kembalikan posisi default jika transform pemain tidak ada.
        }
    }
}
