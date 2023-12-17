using UnityEngine;
using UnityEngine.UI;

public class PocongTriggerTurnBack : MonoBehaviour
{
    public Button TurnBackButton;
    private PocongChase pocongChase;
    public bool enterTriggerArea;
    public bool startChase;

    void Start()
    {
        startChase = false;
        enterTriggerArea = false;
        pocongChase = GetComponentInParent<PocongChase>();

        //get component canvas

        GameObject TurnBackButtonGameObject = GameObject.Find("Canvas/ButtonTurnBack");
        TurnBackButton = TurnBackButtonGameObject.GetComponent<Button>();
        TurnBackButton.onClick.AddListener(HandleButtonTurnBackTrigger);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enterTriggerArea = true;
        }
    }

    public void HandleButtonTurnBackTrigger()
    {

        if (enterTriggerArea == true)
        {
            startChase = true;
            pocongChase.isChase = true;
        }
    }
}
