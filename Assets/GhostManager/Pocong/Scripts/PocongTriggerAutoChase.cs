using UnityEngine;

public class PocongTriggerAutoChase : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pocongChase.isChase = true;
        }
    }

}