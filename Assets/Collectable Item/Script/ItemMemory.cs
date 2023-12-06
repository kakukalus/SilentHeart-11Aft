using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemMemory : MonoBehaviour
{
    // Tambahkan referensi ke TextMeshProUGUI
    public TextMeshProUGUI collectionText;
    // Nama item memory
    public string itemMemoryName;

    // Tombol ambil terkait
    public PickButton pickButton;

    // Flag untuk menandakan apakah item telah diambil
    private bool isPickedUp = false;


    // Metode untuk mengambil item memory
    public void PickUp()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;

            // Tambahkan logika untuk memperbarui TextMeshProUGUI
            UpdateCollectionText();

            Debug.Log($"Collected memory: {itemMemoryName}");

            // Menonaktifkan objek
            gameObject.SetActive(false);
        }
    }

    
    // Fungsi untuk memperbarui teks koleksi
    private void UpdateCollectionText()
    {
        if (collectionText != null)
        {
            // Misalkan Anda ingin menambahkan jumlah koleksi
            // Anda perlu memparse teks yang ada dan menambahkannya dengan 1
            int currentCount = int.Parse(collectionText.text);
            currentCount++;
            collectionText.text = currentCount.ToString();
        }
        else
        {
            Debug.LogError("Collection Text is not set on " + gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            // Mengaktifkan tombol ambil jika tersedia
            pickButton.EnableButton();
            // Atur tombol pick untuk memanggil PickUp ketika diklik
            pickButton.GetComponent<Button>().onClick.AddListener(PickUp);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Menonaktifkan tombol ambil jika tersedia
            pickButton.DisableButton();
            // Hapus listener untuk menghindari panggilan berlebihan
            pickButton.GetComponent<Button>().onClick.RemoveListener(PickUp);
        }
    }
}
