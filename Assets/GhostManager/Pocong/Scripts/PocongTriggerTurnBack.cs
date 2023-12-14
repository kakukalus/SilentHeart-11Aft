using UnityEngine;

public class PocongTriggerTurnBack : MonoBehaviour
{
    private PocongChase pocongChase;
    public bool enterTriggerArea;
    public bool startChase;
    void Start()
    {
        startChase = false;
        enterTriggerArea = false;
        pocongChase = GetComponentInParent<PocongChase>();
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
