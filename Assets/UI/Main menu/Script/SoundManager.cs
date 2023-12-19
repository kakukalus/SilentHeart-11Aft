<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  
  public AudioSource sumberSuara;

  public void ketikaSliderDiubah(float nilaiSlider)
  {
    sumberSuara.volume = nilaiSlider;
  }
=======
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource sumberSuara;
    public Slider sliderVolume; // Pastikan Anda memiliki referensi ke Slider di inspector Unity
    private const string KeyVolume = "Volume";

    private void Start()
    {
        // Memuat volume dan mengatur slider pada posisi yang sesuai
        float savedVolume = PlayerPrefs.GetFloat(KeyVolume, 0.5f); // Default ke 0.5 jika belum ada yang tersimpan
        sliderVolume.value = savedVolume; // Mengatur slider sesuai volume yang disimpan
        sliderVolume.onValueChanged.AddListener(SetVolume);
        SetVolume(savedVolume);
    }

    public void SetVolume(float newValue)
    {
        sumberSuara.volume = newValue;
        PlayerPrefs.SetFloat(KeyVolume, newValue);
        PlayerPrefs.Save(); // Jangan lupa menyimpan perubahan
    }
>>>>>>> 5cb07d58ed10ca197af2fd8ed82831edd9d6d5c4
}
