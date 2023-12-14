using UnityEngine;

public class PocongTriggerJumpScare : MonoBehaviour
{
    private PocongChase pocongChase;
    public JumpscareController jumpscareController;

    void Start()
    {
        pocongChase = GetComponentInParent<PocongChase>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jumpscareController.TriggerJumpScare();
            pocongChase.DestroyThis();
        }
    }



}
