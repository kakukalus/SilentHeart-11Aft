using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MemoryMenuManager : MonoBehaviour
{
    [System.Serializable]
    public class MemoryUIItem
    {
        public string memoryName; // Nama yang sama dengan itemMemoryName di ItemMemory
        public Image memoryImage; // UI Image untuk memory ini di menu utama
    }

    public MemoryUIItem[] memoryUIItems; // Array dari semua UI Items yang ada di main menu

    // Fungsi untuk mengatur opacitas berdasarkan status item memory yang tersimpan
    public void UpdateMemoryUI()
    {
        foreach (var memoryUIItem in memoryUIItems)
        {
            if (memoryUIItem.memoryImage != null)
            {
                // Cek status item memory yang tersimpan
                bool isCollected = PlayerPrefs.GetInt(memoryUIItem.memoryName, 0) == 1;
                SetImageOpacity(memoryUIItem.memoryImage, isCollected ? 1f : 0.3f);
            }
        }
    }

    // Fungsi helper untuk mengatur opacitas dari sebuah image
    private void SetImageOpacity(Image image, float opacity)
    {
        Color color = image.color;
        color.a = opacity;
        image.color = color;
    }

    // Panggil fungsi update saat script ini diaktifkan
    private void OnEnable()
    {
        ItemMemory.OnItemCollected += HandleItemCollected;
        UpdateMemoryUI();
    }

    private void OnDisable()
    {
        ItemMemory.OnItemCollected -= HandleItemCollected;
    }

    private void HandleItemCollected(string itemMemoryName)
    {
    // Cari UI item berdasarkan nama dan perbarui opacitasnya.
        var memoryUIItem = memoryUIItems.FirstOrDefault(item => item.memoryName == itemMemoryName);
        if(memoryUIItem != null)
        {
            SetImageOpacity(memoryUIItem.memoryImage, 1f); // Set full opacity
        }
    }
}
