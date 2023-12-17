using System.Collections;
using System.Collections.Generic;
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
    private Animator baseCharacterAnimator;
    public Slider speedSlider;
    private List<Vector3> originalPositions = new List<Vector3>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCharacterHealth = player.GetComponent<MainCharacterHealth>();
        baseCharacterAnimator = player.GetComponentInChildren<Animator>();

        UIController = new GameObject[7];

        UIController[0] = GameObject.Find("Canvas/SliderMovement");
        UIController[1] = GameObject.Find("Canvas/ButtonTurnBack");
        UIController[2] = GameObject.Find("Canvas/ButtonItemPickItem");
        UIController[3] = GameObject.Find("Canvas/ButtonItemSlot1");
        UIController[4] = GameObject.Find("Canvas/ButtonItemSlot2");
        UIController[5] = GameObject.Find("Canvas/HealthBar");
        UIController[6] = GameObject.Find("Canvas/SanityBar");
        speedSlider = UIController[1].GetComponent<Slider>();

        // Simpan posisi awal UI
        foreach (GameObject canvas in UIController)
        {
            originalPositions.Add(canvas.transform.position);
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

        // Geser UI keluar dari layar
        foreach (GameObject canvas in UIController)
        {
            // Geser UI ke luar layar
            canvas.transform.Translate(Vector3.right * Screen.width);
        }

        // Tampilkan gambar jumpscare
        UIPocongJumscare.SetActive(true);
        baseCharacterAnimator.SetTrigger("getJumpsace");

        // Tunggu beberapa detik
        yield return new WaitForSeconds(jumpscareDuration);

        // Sembunyikan gambar jumpscare
        UIPocongJumscare.SetActive(false);

        if (mainCharacterHealth.currentHealth > 0f)
        {
            for (int i = 0; i < UIController.Length; i++)
            {
                UIController[i].transform.position = originalPositions[i];
            }
        }
    }
}
