using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class SliderMovement : MonoBehaviour, IPointerUpHandler// required interface when using the OnPointerDown method.
{
    //Do this when the mouse is clicked over the selectable object this script is attached to.


    public float returnDelay = 1f;
    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Slider>().value = 0.0f;
    }


}