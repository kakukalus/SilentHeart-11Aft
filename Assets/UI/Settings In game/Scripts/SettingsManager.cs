using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // Referensi ke panel pengaturan Anda
    
    // Fungsi untuk mem-pause game dan menampilkan panel pengaturan
    public void OpenSettings()
    {
        Time.timeScale = 0; // Menghentikan waktu game, yang efektif mem-pause semua operasi yang bergantung pada waktu
        settingsPanel.SetActive(true); // Menampilkan panel pengaturan
    }


    // Fungsi untuk melanjutkan game, bisa dipanggil saat tombol play ditekan
    public void PlayGame()
    {
        Time.timeScale = 1; // Melanjutkan waktu game
        // Optional: Sembunyikan panel pengaturan jika Anda ingin itu hilang saat game dilanjutkan
        settingsPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Memuat ulang scene
    }

}
