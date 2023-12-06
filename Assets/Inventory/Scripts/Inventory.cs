using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Array untuk menyimpan slot-slot inventori
    public InventorySlot[] slots;

    // Item yang sedang ditargetkan
    private Item targetedItem;

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
}
