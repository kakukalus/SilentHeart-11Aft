using UnityEngine;
using UnityEngine.UI;

public class PickButton : MonoBehaviour
{
    private Item associatedItem; // Item yang terkait dengan tombol ini.

    // Inisialisasi tombol ambil dengan item dan inventori pemain.
    public void Initialize(Item item, Inventory playerInventory)
    {
        associatedItem = item; // Tetapkan item terkait.
        GetComponent<Button>().onClick.RemoveAllListeners(); // Hapus semua listener sebelumnya.

        // Menambahkan listener baru pada tombol.
        GetComponent<Button>().onClick.AddListener(() => {
            if (playerInventory == null || !playerInventory.IsInventoryFull())
            {
                associatedItem.PickUp(); // Jalankan fungsi PickUp pada item jika inventori belum penuh.
            }
            else
            {
                Debug.Log("Inventori penuh. Tidak bisa mengambil item."); // Log jika inventori penuh.
            }
        });
    }

    // Inisialisasi tombol untuk item tertentu dengan aksi kustom.
    public void InitializeForMemoryItem(System.Action pickUpAction)
    {
        GetComponent<Button>().onClick.RemoveAllListeners(); // Hapus semua listener sebelumnya.
        GetComponent<Button>().onClick.AddListener(() => pickUpAction()); // Tetapkan aksi kustom saat tombol diklik.
    }

    // Menonaktifkan tombol.
    public void DisableButton()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false); // Nonaktifkan objek tombol.
        }
    }

    // Mengaktifkan tombol.
    public void EnableButton()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(true); // Aktifkan objek tombol.
        }
    }
}
