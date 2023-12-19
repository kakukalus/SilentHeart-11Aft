using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public float typingSpeed;
    public GameObject panelDialog;
    public Button settingsButton;
    public GameObject continueButton;

    private string[] sentences; // Ini akan diisi oleh DialogTrigger
    private int index;



    void Update()
    {
        // Tambahkan pengecekan untuk memastikan bahwa 'sentences' tidak null dan 'index' tidak melebihi panjang array
        if(sentences != null && index < sentences.Length && textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }



    public void StartDialog(string[] sentencesToDisplay)
    {
        sentences = sentencesToDisplay;
         if(sentencesToDisplay == null || sentencesToDisplay.Length == 0)
        {
            Debug.LogError("Tidak ada kalimat yang diberikan untuk StartDialog");
            return;
        }
        Time.timeScale = 0; // Pause the game
        settingsButton.interactable = false;
        index = 0;
        textDisplay.text = "";
        panelDialog.SetActive(true);
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }


    // IEnumerator StartTypingWithDelay()
    // {
    //     // Tidak perlu delay saat game sedang pause
    //     StartCoroutine(Type());
    // }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed); // Pastikan ini diatur di inspector
        }
        continueButton.SetActive(true); // Aktifkan continue button setelah mengetik selesai
    }


    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            continueButton.SetActive(false);
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            panelDialog.SetActive(false);
            settingsButton.interactable = true; // Aktifkan button settings
            Time.timeScale = 1; // Resume the game
        }
    }

    public void ActivateDialog()
    {
        index = 0; // Reset dialog ke kalimat pertama
        textDisplay.text = ""; // Kosongkan text display
        continueButton.SetActive(true); // Tampilkan tombol continue
        StartCoroutine(Type()); // Mulai mengetik kalimat
    }


}
