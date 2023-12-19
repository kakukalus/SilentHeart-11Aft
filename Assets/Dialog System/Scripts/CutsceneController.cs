using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneController : MonoBehaviour
{
    public Image cutsceneImage;
    public TextMeshProUGUI dialogText;
    public string[] dialogLines; // Array of dialog lines for the cutscene
    public Sprite[] cutsceneSprites; // Array of images for the cutscene
    public float typingSpeed = 0.05f;
    public float timeBetweenScenes = 5.0f; // Time in seconds to wait before changing scene
    public float fadeDuration = 1.0f; // Durasi untuk fade in dan fade out

    private void Start()
    {
        // Set opacitas awal gambar pertama menjadi redup (0)
        cutsceneImage.color = new Color(cutsceneImage.color.r, cutsceneImage.color.g, cutsceneImage.color.b, 0);
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        // ... Cek panjang array ...

        for (int i = 0; i < cutsceneSprites.Length; i++)
        {
            cutsceneImage.sprite = cutsceneSprites[i];
            yield return StartCoroutine(FadeImage(cutsceneImage, true)); // Fade in
            yield return StartCoroutine(TypeLine(dialogLines[i]));
            yield return new WaitForSeconds(timeBetweenScenes - fadeDuration);
            yield return StartCoroutine(FadeImage(cutsceneImage, false)); // Fade out
        }

        SceneManager.LoadScene("MapLevel1");
    }

    IEnumerator TypeLine(string line)
    {
        dialogText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }

    IEnumerator FadeImage(Image image, bool fadeIn)
    {
        float targetAlpha = fadeIn ? 1.0f : 0.0f;
        float alpha = image.color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeDuration)
        {
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(alpha, targetAlpha, t));
            image.color = newColor;
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, targetAlpha);
    }
}
