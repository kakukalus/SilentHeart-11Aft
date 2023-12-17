using UnityEngine;

public class PocongTriggerChase : MonoBehaviour
{
    private PocongChase pocongChase;
    public PocongTriggerTurnBack pocongTriggerTurnBack;
    public bool startChase;
    void Start()
    {
        pocongChase = GetComponentInParent<PocongChase>();
    }

    void Update()
    {
        startChase = pocongTriggerTurnBack.startChase;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && startChase == true)
        {
            pocongChase.isChase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && pocongChase.isChase == true)
        {
            pocongChase.isChase = false;
            pocongChase.DestroyThis();
        }
    }
}