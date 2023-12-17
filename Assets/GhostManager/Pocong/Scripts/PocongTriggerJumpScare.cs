using UnityEngine;

public class PocongTriggerJumpScare : MonoBehaviour
{
    public float damage;
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
        damage = 25f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mainCharacterHealth.TakeDamage(damage);
            jumpscareController.TriggerJumpscarePocong();
            pocongChase.DestroyThis();
        }
    }



}
