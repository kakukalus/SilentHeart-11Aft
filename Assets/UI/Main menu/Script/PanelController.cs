using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject settingsCanvas; // Referensi ke panel pengaturan Anda
    public GameObject canvasMenu; // Referensi ke panel pengaturan Anda
    public GameObject menuPanel; // Seret panel menu Anda ke dalam slot ini di inspector Unity
    public GameObject PanelMemory; // Seret panel menu Anda ke dalam slot ini di inspector Unity
    public GameObject popUpQuit; // Seret panel setting ke dalam slot ini di inspector Unity
    public GameObject panelSetting; // Seret panel setting ke dalam slot ini di inspector Unity

    void Start()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu saat memulai game
    }

    public void NewGame()
    {
        ResetGameData();
        SceneManager.LoadScene("TestCharacterDimas");
        SceneManager.sceneLoaded += OnSceneLoaded;
        Time.timeScale = 1;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TestCharacterDimas")
        {
            // Reset dialog triggers
            DialogTrigger[] allDialogTriggers = FindObjectsOfType<DialogTrigger>();
            foreach (var trigger in allDialogTriggers)
            {
                trigger.ResetTrigger();
            }

            // Remove the listener to prevent it from being called again on subsequent scene loads
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void ResetGameData()
    {
        // Reset posisi checkpoint dan kesehatan pemain
        PlayerPrefs.DeleteKey("CheckpointX");
        PlayerPrefs.DeleteKey("CheckpointY");
        PlayerPrefs.DeleteKey("CheckpointZ");
        PlayerPrefs.DeleteKey("PlayerHealth");
        PlayerPrefs.DeleteKey("CurrentLevel");
        PlayerPrefs.DeleteKey("PlayerSanity");

        // Reset semua item fragment / memory yang telah dikumpulkan
        PlayerPrefs.SetInt("TotalCollectedItems", 0);
        PlayerPrefs.DeleteKey("Item Memory 1");
        PlayerPrefs.DeleteKey("Item Memory 2");
        PlayerPrefs.DeleteKey("Item Memory 3");
<<<<<<< HEAD

=======
        
        
>>>>>>> 5cb07d58ed10ca197af2fd8ed82831edd9d6d5c4
        // Tambahkan penghapusan kunci untuk inventori
        int numberOfInventorySlots = 2; // Ganti dengan jumlah sebenarnya dari slot inventori Anda
        for (int i = 0; i < numberOfInventorySlots; i++)
        {
            PlayerPrefs.DeleteKey($"InventorySlot{i}");
        }

        PlayerPrefs.Save(); // Jangan lupa untuk menyimpan perubahan setelah menghapus
    }

<<<<<<< HEAD

    // Fungsi untuk menampilkan panel memori
    public void ShowMemoryPanel()
    {
        menuPanel.SetActive(false); // Sembunyikan panel menu
        memoryPanelLevel1.SetActive(true); // Menampilkan panel memori
    }

    public void BackToMenuForMemory()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu
        memoryPanelLevel1.SetActive(false); // Sembunyikan panel memori
        memoryPanelLevel2.SetActive(false); // Sembunyikan panel memori
    }

    public void NextMemory2()
    {
        memoryPanelLevel1.SetActive(false); // Sembunyikan panel memori
        memoryPanelLevel2.SetActive(true); // Menampilkan panel memori
    }

    public void PreviousMemory1()
    {
        memoryPanelLevel1.SetActive(true); // Menampilkan panel memori
        memoryPanelLevel2.SetActive(false); // Sembunyikan panel memori
    }

    public void ShowSettingControls()
    {
        menuPanel.SetActive(false); // Sembunyikan panel menu
        settingControls.SetActive(true); // Menampilkan panel setting
    }

    public void ShowSettingSound()
    {
        settingControls.SetActive(false); // Sembunyikan panel setting
        settingSoundBtn.SetActive(true); // Menampilkan panel setting
    }

    public void ShowSettingText()
    {
        settingControls.SetActive(false); // Sembunyikan panel setting
        settingTextBtn.SetActive(true); // Menampilkan panel setting
    }

    public void BackToControllForSound()
    {
        settingSoundBtn.SetActive(false); // Sembunyikan panel setting
        settingControls.SetActive(true); // Menampilkan panel setting
    }

    public void BackToTextForSound()
    {
        settingSoundBtn.SetActive(false); // Sembunyikan panel setting
        settingTextBtn.SetActive(true); // Menampilkan panel setting
    }

    public void BackToControllForText()
    {
        settingTextBtn.SetActive(false); // Sembunyikan panel setting
        settingControls.SetActive(true); // Menampilkan panel setting
    }

    public void BackToSoundForText()
    {
        settingTextBtn.SetActive(false); // Sembunyikan panel setting
        settingSoundBtn.SetActive(true); // Menampilkan panel setting
    }

    public void BackToMenuForControls()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu
        settingControls.SetActive(false); // Sembunyikan panel setting
    }

    public void BackToMenuForSound()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu
        settingSoundBtn.SetActive(false); // Sembunyikan panel setting
    }

    public void BackToMenuForText()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu
        settingTextBtn.SetActive(false); // Sembunyikan panel setting
    }
=======
    public void OpenFragment()
    {
        canvasMenu.SetActive(false); // Sembunyikan panel menu
        PanelMemory.SetActive(true); // Menampilkan panel setting
        settingsCanvas.SetActive(true); // Sembunyikan panel menu
    }

    public void BackToMainMenu()
    {
        canvasMenu.SetActive(true); // Tampilkan panel menu
        menuPanel.SetActive(true); // Sembunyikan panel setting
        PanelMemory.SetActive(false); // Sembunyikan panel setting
        settingsCanvas.SetActive(false); // Sembunyikan panel menu
        panelSetting.SetActive(false); // Sembunyikan panel menu
    }

    public void OpenSettings()
    {
        settingsCanvas.SetActive(true); // Menampilkan panel pengaturan
        menuPanel.SetActive(false); // Sembunyikan panel menu
        canvasMenu.SetActive(false); // Sembunyikan panel menu
        panelSetting.SetActive(true); // Sembunyikan panel menu
    }


    // public void OpenSettings()
    // {
    //     settingsCanvas.SetActive(true); // Menampilkan panel pengaturan
    //     menuPanel.SetActive(false); // Sembunyikan panel menu
    // }

    // public void CloseSettings()
    // {
    //     canvasMenu.SetActive(true); // Menampilkan panel pengaturan
    //     settingsCanvas.SetActive(false); // Sembunyikan panel menu
    //     menuPanel.SetActive(true); // Sembunyikan panel menu
    // }

    // public void ShowMemory()
    // {
    //     PanelMemory.SetActive(true); // Sembunyikan panel menu
    //     canvasMenu.SetActive(false); // Sembunyikan panel menu
    // }
>>>>>>> 5cb07d58ed10ca197af2fd8ed82831edd9d6d5c4

    public void ShowPopUpQuit()
    {
        menuPanel.SetActive(false); // Sembunyikan panel menu
        popUpQuit.SetActive(true); // Menampilkan panel setting
    }

    public void BackToMenuForQuitPopUp()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu
        popUpQuit.SetActive(false); // Sembunyikan panel setting
    }

    public void QuitGame()
    {
        Application.Quit(); // Keluar dari game
        Debug.Log("Quit"); // Debug
    }

}
