using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject panelDialog;
    public GameObject continueButton;
    public Button settingsButton; // Tambahkan ini untuk referensi button settings



    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
        textDisplay.gameObject.transform.parent.gameObject.SetActive(false);
        StartCoroutine(Type());
    }


    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }


    public void StartDialog()
    {
        Time.timeScale = 0; // Pause the game
        settingsButton.interactable = false; // Nonaktifkan button settings
        index = 0;
        textDisplay.text = "";
        panelDialog.SetActive(true);
        continueButton.SetActive(false);
        StartCoroutine(Type()); // Langsung memanggil Type tanpa delay
    }



    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed); // Gunakan WaitForSecondsRealtime agar berfungsi saat pause
        }

        continueButton.SetActive(true);
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
