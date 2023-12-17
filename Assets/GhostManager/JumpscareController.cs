
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JumpscareController : MonoBehaviour
{
    public float jumpscareDuration = 3f;
    public GameObject[] UIController;
    public GameObject UIPocongJumscare;
    public GameObject UIKuntilanakJumpscare;
    public GameObject sanityFrame;
    private Transform player;
    public MainCharacterHealth mainCharacterHealth;
    public Slider speedSlider;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCharacterHealth = player.GetComponent<MainCharacterHealth>();

        UIController = new GameObject[7];

        UIController[0] = GameObject.Find("Canvas/SliderMovement");
        UIController[1] = GameObject.Find("Canvas/ButtonTurnBack");
        UIController[2] = GameObject.Find("Canvas/ButtonItemPickItem");
        UIController[3] = GameObject.Find("Canvas/ButtonItemSlot1");
        UIController[4] = GameObject.Find("Canvas/ButtonItemSlot2");
        UIController[5] = GameObject.Find("Canvas/HealthBar");
        UIController[6] = GameObject.Find("Canvas/SanityBar");
        speedSlider = UIController[1].GetComponent<Slider>();
        foreach (GameObject canvas in UIController)
        {
            canvas.gameObject.SetActive(true);
        }

        UIPocongJumscare = GameObject.Find("Canvas/pocongJumpscare");
        UIPocongJumscare.SetActive(false);

    }

    public void TriggerJumpscarePocong()
    {
        StartCoroutine(JumpscarePocong());
    }


    private IEnumerator JumpscarePocong()
    {

        foreach (GameObject canvas in UIController)
        {
            canvas.gameObject.SetActive(false);
        }

        // Tampilkan gambar jumpscare
        UIPocongJumscare.SetActive(true);

        // Tunggu beberapa detik
        yield return new WaitForSeconds(jumpscareDuration);

        // Sembunyikan gambar jumpscare
        UIPocongJumscare.SetActive(false);

        if (mainCharacterHealth.currentHealth > 0f)
        {
            // Munculkan kembali UI
            foreach (GameObject canvas in UIController)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }
}
