using UnityEngine;

public class PocongTriggerJumpScare : MonoBehaviour
{
    private PocongChase pocongChase;
    public JumpscareController jumpscareController;
    private Transform player;
    private MainCharacterHealth mainCharacterHealth;
    void Start()
    {
        GameObject gameManager = GameObject.Find("GameManager");
        jumpscareController = gameManager.GetComponent<JumpscareController>();
        pocongChase = GetComponentInParent<PocongChase>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCharacterHealth = player.GetComponent<MainCharacterHealth>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mainCharacterHealth.TakeDamage(30f);
            jumpscareController.TriggerJumpscarePocong();
            pocongChase.DestroyThis();
        }
    }



}
