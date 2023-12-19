using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ItemMemory : MonoBehaviour
{
    public TextMeshProUGUI collectionText; // Referensi ke UI TextMeshPro untuk menampilkan jumlah item yang telah dikumpulkan.
    public static event Action<string> OnItemCollected; // Event untuk notifikasi item yang dikumpulkan
    public string itemMemoryName; // Nama dari item memory ini, digunakan untuk identifikasi.
    public string[] dialogOnPickup; // Kalimat-kalimat dialog yang akan muncul ketika item diambil
    // public Sprite[] dialogSprites; // Array Sprite untuk gambar dialog
    public DialogManager dialogManager; // Referensi ke DialogManager
    public PickButton pickButton; // Referensi ke tombol ambil yang terkait dengan item ini.

    private bool isPickedUp = false; // Status yang menandakan apakah item telah diambil.

    // Di dalam metode Start() atau Awake()
    private void Start()
    {
        // Periksa apakah item ini sudah dikumpulkan berdasarkan data yang tersimpan.
        if (PlayerPrefs.GetInt(itemMemoryName, 0) == 1)
        {
            isPickedUp = true;
            gameObject.SetActive(false); // Nonaktifkan game object jika item sudah dikumpulkan sebelumnya.
        }
        else
        {
            isPickedUp = false;
        }

        UpdateCollectionTextOnStart(); // Perbarui teks koleksi ketika scene dimulai.
    }

    // Metode untuk mengambil item memory.
    public void PickUp()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;

            // Menyimpan status item sebagai telah dikumpulkan.
            PlayerPrefs.SetInt(itemMemoryName, 1); // Simpan dengan nilai 1 yang menandakan telah dikumpulkan.
            PlayerPrefs.Save();

            // Notifikasi bahwa item telah dikumpulkan.
            OnItemCollected?.Invoke(itemMemoryName);

            // Perbarui UI dan tampilkan log.
            UpdateCollectionText();
            Debug.Log($"Collected memory: {itemMemoryName}");
            // Cek jika ada dialog yang terkait dengan pengambilan item ini
            if (dialogOnPickup.Length > 0 && dialogManager != null)
            {
                dialogManager.StartDialog(dialogOnPickup); // Memulai dialog yang terkait dengan item ini
            }
            else
            {
                Debug.LogWarning($"No dialog is set for {itemMemoryName} or DialogManager is not assigned.");
            }

            gameObject.SetActive(false); // Nonaktifkan objek setelah dikumpulkan.

        }
    }

    // Fungsi untuk memperbarui teks koleksi.
    private void UpdateCollectionText()
    {
        if (collectionText != null)
        {
            int currentCount = int.Parse(collectionText.text); // Dapatkan jumlah koleksi saat ini dari teks UI.
            currentCount++; // Tambahkan satu ke jumlah tersebut.
            collectionText.text = currentCount.ToString(); // Perbarui teks UI dengan jumlah terbaru.

            // Simpan jumlah koleksi yang telah diperbarui.
            PlayerPrefs.SetInt("TotalCollectedItems", currentCount);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("Collection Text is not set on " + gameObject.name); // Tampilkan error jika TextMeshProUGUI tidak diatur.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            // Aktifkan tombol ambil ketika pemain mendekat dan item belum dikumpulkan.
            if (pickButton != null)
            {
                pickButton.EnableButton();
                pickButton.GetComponent<Button>().onClick.AddListener(PickUp); // Tambahkan listener ke tombol.
            }
            else
            {
                Debug.LogError("PickButton is not assigned in the inspector."); // Tampilkan error jika PickButton tidak diatur.
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Nonaktifkan tombol ambil ketika pemain menjauh.
            if (pickButton != null)
            {
                pickButton.DisableButton();
                pickButton.GetComponent<Button>().onClick.RemoveListener(PickUp); // Hapus listener dari tombol.
            }
            else
            {
                Debug.LogError("PickButton is not assigned in the inspector."); // Tampilkan error jika PickButton tidak diatur.
            }
        }
    }

    // Memperbarui teks koleksi saat scene dimulai.
    private void UpdateCollectionTextOnStart()
    {
        int totalCollectedItems = PlayerPrefs.GetInt("TotalCollectedItems", 0); // Dapatkan total item yang telah dikumpulkan.
        if (collectionText != null)
        {
            collectionText.text = totalCollectedItems.ToString(); // Perbarui teks UI dengan total yang dikumpulkan.
        }
        else
        {
            Debug.LogError("Collection Text is not set in the inspector."); // Tampilkan error jika TextMeshProUGUI tidak diatur.
        }
    }

    public void ResetGame()
    {
        // Reset jumlah total item koleksi.
        PlayerPrefs.SetInt("TotalCollectedItems", 0);
        PlayerPrefs.Save();

        UpdateCollectionTextOnStart(); // Perbarui UI setelah mereset.
    }
}
