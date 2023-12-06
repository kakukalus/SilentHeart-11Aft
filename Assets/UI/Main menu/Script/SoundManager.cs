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
}
