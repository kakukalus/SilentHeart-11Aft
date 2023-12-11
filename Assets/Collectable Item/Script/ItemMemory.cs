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


    // Di dalam metode Start() atau Awake()
    private void Start()
    {
        // Periksa apakah item ini sudah dikumpulkan
        if (PlayerPrefs.GetInt(itemMemoryName, 0) == 1)
        {
            isPickedUp = true;
            gameObject.SetActive(false); // Sembunyikan jika sudah dikumpulkan
        }
        else
        {
            isPickedUp = false;
        }

        UpdateCollectionTextOnStart();
    }

    // Metode untuk mengambil item memory
    public void PickUp()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;

            // Menyimpan status item sebagai telah dikumpulkan
            PlayerPrefs.SetInt(itemMemoryName, 1); // 1 untuk dikumpulkan
            PlayerPrefs.Save();

            // Update UI dan lainnya
            UpdateCollectionText();
            Debug.Log($"Collected memory: {itemMemoryName}");
            gameObject.SetActive(false);
        }
    }


    
    // Fungsi untuk memperbarui teks koleksi
    private void UpdateCollectionText()
    {
        if (collectionText != null)
        {
            int currentCount = int.Parse(collectionText.text);
            currentCount++;
            collectionText.text = currentCount.ToString();

            // Menyimpan jumlah koleksi saat ini
            PlayerPrefs.SetInt("TotalCollectedItems", currentCount);
            PlayerPrefs.Save();
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
            // Pastikan pickButton tidak null sebelum mengaksesnya
            if (pickButton != null)
            {
                pickButton.EnableButton();
                pickButton.GetComponent<Button>().onClick.AddListener(PickUp);
            }
            else
            {
                Debug.LogError("PickButton is not assigned in the inspector.");
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Pastikan pickButton tidak null sebelum mengaksesnya
            if (pickButton != null)
            {
                pickButton.DisableButton();
                pickButton.GetComponent<Button>().onClick.RemoveListener(PickUp);
            }
            else
            {
                Debug.LogError("PickButton is not assigned in the inspector.");
            }
        }
    }


    // Memperbarui teks koleksi saat scene dimulai
    private void UpdateCollectionTextOnStart()
    {
        // Mendapatkan jumlah total item koleksi dari PlayerPrefs
        int totalCollectedItems = PlayerPrefs.GetInt("TotalCollectedItems", 0);
        // Pastikan referensi TextMeshProUGUI sudah diatur
        if (collectionText != null)
        {
            collectionText.text = totalCollectedItems.ToString();
        }
        else
        {
            Debug.LogError("Collection Text is not set in the inspector.");
        }
    }


    public void ResetGame()
    {
        // Reset jumlah total item koleksi
        PlayerPrefs.SetInt("TotalCollectedItems", 0);
        PlayerPrefs.Save();

            // Pastikan untuk memperbarui UI setelah mereset
        UpdateCollectionTextOnStart();
    }

}
