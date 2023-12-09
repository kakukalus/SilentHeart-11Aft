using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Array untuk menyimpan slot-slot inventori
    public InventorySlot[] slots;

    // Asumsikan array ini diisi melalui Unity Editor atau di awal game
    public Item[] allAvailableItems;

    // Item yang sedang ditargetkan
    private Item targetedItem;

    // Pastikan ini dipanggil setelah scene selesai dimuat
    private void Start()
    {
        LoadInventory();
    }


    // Menetapkan item sebagai target
    public void TargetItem(Item item)
    {
        targetedItem = item;
    }

    // Membatalkan item sebagai target
    public void UntargetItem(Item item)
    {
        if (targetedItem == item)
        {
            targetedItem = null;
        }
    }

    // Mengambil item yang sedang ditargetkan dan menambahkannya ke inventori
    public void PickUpItem()
    {
        if (targetedItem != null && !IsInventoryFull())
        {
            AddItem(targetedItem);
            targetedItem.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Cannot pick up item: Inventory is full or no item targeted.");
        }
    }

    // Menambahkan item ke inventori
    public bool AddItem(Item itemToAdd)
    {
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.AssignItem(itemToAdd);
                return true; // Item berhasil ditambahkan
            }
        }
        Debug.Log("Inventory is full!");
        return false; // Inventori penuh, item tidak berhasil ditambahkan
    }

    // Menangani klik tombol ambil item
    public void OnPickUpButtonClicked()
    {
        if (targetedItem != null)
        {
            targetedItem.PickUp();
            AddItem(targetedItem);
            targetedItem.pickButton.DisableButton();
        }
    }

    // Memeriksa apakah inventori penuh
    public bool IsInventoryFull()
    {
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                return false; // Ada slot kosong, inventori tidak penuh
            }
        }
        return true; // Tidak ada slot kosong, inventori penuh
    }

     public void LoadInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            string itemName = PlayerPrefs.GetString($"InventorySlot{i}", "");
            if (!string.IsNullOrEmpty(itemName))
            {
                Item item = GetItemByName(itemName);
                if (item != null)
                {
                    slots[i].AssignItem(item);
                }
            }
        }
    }

    private Item GetItemByName(string itemName)
    {
        foreach (var item in allAvailableItems)
        {
            if (item.itemName == itemName)
            {
                // Instantiate item jika Anda menyimpan prefab, atau cukup kembalikan item jika tidak.
                // Item instantiatedItem = Instantiate(item);
                // return instantiatedItem;
                return item;
            }
        }

        // Jika tidak ada item yang cocok, kembalikan null
        return null;
    }
}
