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
        index = 0; // Reset ke kalimat pertama
        textDisplay.text = ""; // Kosongkan text display
        panelDialog.SetActive(true); // Aktifkan panel dialog
        continueButton.SetActive(false); // Sembunyikan tombol continue

        if (index == 0) // Jika ini adalah kalimat pertama
        {
            StartCoroutine(StartTypingWithDelay()); // Mulai mengetik dengan delay
        }
        else
        {
            StartCoroutine(Type()); // Mulai mengetik tanpa delay
        }
    }


    IEnumerator StartTypingWithDelay()
    {
        yield return new WaitForSeconds(0.3f); // Menunggu selama 1 detik sebelum memulai mengetik untuk kalimat pertama
        StartCoroutine(Type()); // Lalu mulai mengetik
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        continueButton.SetActive(true); // Aktifkan tombol continue setelah selesai mengetik
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
            panelDialog.SetActive(false); // Menonaktifkan panel dialog setelah kalimat terakhir
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
