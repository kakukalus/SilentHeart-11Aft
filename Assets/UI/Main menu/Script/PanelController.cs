using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour
{
    public GameObject menuPanel; // Seret panel menu Anda ke dalam slot ini di inspector Unity
    public GameObject memoryPanelLevel1; // Seret panel level 1 ke dalam slot ini di inspector Unity
    public GameObject memoryPanelLevel2; // Seret panel level 2 ke dalam slot ini di inspector Unity
    public GameObject settingControls; // Seret panel setting ke dalam slot ini di inspector Unity
    public GameObject settingSoundBtn; // Seret panel setting ke dalam slot ini di inspector Unity
    public GameObject settingTextBtn; // Seret panel setting ke dalam slot ini di inspector Unity
    public GameObject popUpQuit; // Seret panel setting ke dalam slot ini di inspector Unity

    void Start()
    {
        menuPanel.SetActive(true); // Tampilkan panel menu saat memulai game
    }

    public void NewGame()
    {
        SceneManager.LoadScene("TestCharacterDimas"); // Memuat ulang scene
    }

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
