using UnityEngine;
using UnityEngine.UI;

public class PickButton : MonoBehaviour
{
    private Item associatedItem;

    // Metode untuk menginisialisasi tombol ambil
    public void Initialize(Item item, Inventory playerInventory)
    {
        associatedItem = item;

        // Hapus semua listener yang ada sebelum menambahkan yang baru
        GetComponent<Button>().onClick.RemoveAllListeners();

        // Menambahkan listener untuk mengambil item saat tombol diklik
        GetComponent<Button>().onClick.AddListener(() => {
            if (playerInventory == null || !playerInventory.IsInventoryFull())
            {
                associatedItem.PickUp();
            }
            else
            {
                // Menampilkan pesan bahwa inventori penuh
                Debug.Log("Inventory is full. Can't pick up the item.");
            }
        });
    }


        public void InitializeForMemoryItem(System.Action pickUpAction)
    {
        // Hapus semua listener yang ada
        GetComponent<Button>().onClick.RemoveAllListeners();
        // Menambahkan listener untuk mengambil item saat tombol diklik
        GetComponent<Button>().onClick.AddListener(() => pickUpAction());
    }


    // Menonaktifkan tombol
    public void DisableButton()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }

    // Mengaktifkan tombol
    public void EnableButton()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(true);
        }
    }
}
