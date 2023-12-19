using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // Referensi ke panel pengaturan Anda
    public GameObject inSettingsPanel;
    // Fungsi untuk mem-pause game dan menampilkan panel pengaturan
    public void OpenSettings()
    {
        Time.timeScale = 0; // Menghentikan waktu game, yang efektif mem-pause semua operasi yang bergantung pada waktu
        settingsPanel.SetActive(true); // Menampilkan panel pengaturan
    }

    public void inSettingsPanelOpen()
    {
        settingsPanel.SetActive(false);
        inSettingsPanel.SetActive(true);
        
    }

    public void inSettingsPanelClose()
    {
        settingsPanel.SetActive(true);
        inSettingsPanel.SetActive(false);
    }

    // Fungsi untuk melanjutkan game, bisa dipanggil saat tombol play ditekan
    public void PlayGame()
    {
        Time.timeScale = 1; // Melanjutkan waktu game
        // Optional: Sembunyikan panel pengaturan jika Anda ingin itu hilang saat game dilanjutkan
        settingsPanel.SetActive(false);
        inSettingsPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Memuat ulang scene
    }

}
