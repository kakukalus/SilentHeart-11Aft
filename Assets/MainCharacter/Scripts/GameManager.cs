
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] UIController;

    void Start()
    {
        UIController = new GameObject[7];

        UIController[0] = GameObject.Find("Canvas/SliderMovement");
        UIController[1] = GameObject.Find("Canvas/ButtonTurnBack");
        UIController[2] = GameObject.Find("Canvas/ButtonItemPickItem");
        UIController[3] = GameObject.Find("Canvas/ButtonItemSlot1");
        UIController[4] = GameObject.Find("Canvas/ButtonItemSlot2");
        UIController[5] = GameObject.Find("Canvas/HealthBar");
        UIController[6] = GameObject.Find("Canvas/SanityBar");
        foreach (GameObject canvas in UIController)
        {
            canvas.gameObject.SetActive(true);
        }

    }

    public void PlayerDied()
    {

        foreach (GameObject canvas in UIController)
        {
            canvas.gameObject.SetActive(false);
        }

    }
}
