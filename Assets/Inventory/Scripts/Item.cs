using UnityEngine;

public class Item : MonoBehaviour
{
    // Nama item
    public string itemName;

    // Tombol ambil terkait
    public PickButton pickButton;

    // Transform pemain
    public Transform player;

    // Flag untuk menandakan apakah item telah diambil
    private bool isPickedUp = false;

    // Metode yang dapat dioverride untuk penggunaan item
    public virtual void Use()
    {
        Debug.Log("Base Item Used");
    }

    // Dipanggil ketika objek bersentuhan dengan pemain
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponent<Inventory>();

            // Mengaktifkan tombol ambil jika tersedia
            if (pickButton != null && playerInventory != null)
            {
                pickButton.EnableButton();
                pickButton.Initialize(this, playerInventory);
            }

            // Menetapkan item sebagai target di inventori pemain
            other.GetComponent<Inventory>().TargetItem(this);
        }
    }

    // Dipanggil ketika objek keluar dari area pemain
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Menonaktifkan tombol ambil jika tersedia
            if (pickButton != null)
            {
                pickButton.DisableButton();
            }

            // Membatalkan item sebagai target di inventori pemain
            other.GetComponent<Inventory>().UntargetItem(this);
        }
    }

    // Mengambil item
    public void PickUp()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
            gameObject.SetActive(false);

            // Menonaktifkan tombol ambil jika tersedia
            if (pickButton != null)
            {
                pickButton.DisableButton();
            }

            Debug.Log($"Picked up {itemName}.");
        }
    }

    // Melepaskan item
    public void Drop()
    {
        gameObject.SetActive(true);
        transform.position = CalculateDropPosition();
    }

    // Menghitung posisi drop
    private Vector3 CalculateDropPosition()
    {
        if (player != null)
        {
            return new Vector3(player.position.x, player.position.y + 0.3f, player.position.z);
        }
        else
        {
            Debug.LogError("Player transform is null. Make sure to assign it in the inspector.");
            return Vector3.zero;
        }
    }
}
