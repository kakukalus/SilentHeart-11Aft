using UnityEngine;

public class PocongTriggerJumpScare : MonoBehaviour
{
    private PocongChase pocongChase;
    public JumpscareController jumpscareController;

    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        jumpscareController = gameManager.GetComponent<JumpscareController>();
        pocongChase = GetComponentInParent<PocongChase>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jumpscareController.TriggerJumpscarePocong();
            pocongChase.DestroyThis();
        }
    }



}
