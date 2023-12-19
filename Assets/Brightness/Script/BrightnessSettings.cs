using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    public Volume volume; // Referensi ke Volume di scene Anda
    public Slider brightnessSlider; // Referensi ke UI Slider
    private const string KeyBrightness = "Brightness";

    private void Start()
    {
        // Pastikan untuk inisialisasi slider dengan nilai yang disimpan atau nilai default
        float savedBrightness = PlayerPrefs.GetFloat(KeyBrightness, 0.5f); // Default ke 0.5 jika belum ada yang tersimpan
        brightnessSlider.value = savedBrightness; // Mengatur slider sesuai kecerahan yang disimpan
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
        SetBrightness(savedBrightness);
    }

    public void SetBrightness(float newBrightness)
    {
        if(volume.profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            colorAdjustments.postExposure.value = newBrightness;
            PlayerPrefs.SetFloat(KeyBrightness, newBrightness);
            PlayerPrefs.Save(); // Jangan lupa menyimpan perubahan
        }
    }
}
