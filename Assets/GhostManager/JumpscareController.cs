using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JumpscareController : MonoBehaviour
{
    public float jumpscareDuration = 3f;
    public GameObject[] UIController;
    public List<RectTransform> currentRectTransforms = new List<RectTransform>();
    public List<Vector3> originalPositions = new List<Vector3>();
    private RectTransform UiHidePlace;
    public GameObject UIPocongJumscare;
    public GameObject UIKuntilanakJumpscare;
    public GameObject sanityFrame;
    private Transform player;
    public MainCharacterHealth mainCharacterHealth;
    private Animator baseCharacterAnimator;
    public Slider speedSlider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCharacterHealth = player.GetComponent<MainCharacterHealth>();
        baseCharacterAnimator = player.GetComponentInChildren<Animator>();

        UIController = new GameObject[8];

        UIController[0] = GameObject.Find("Canvas/SliderMovement");
        UIController[1] = GameObject.Find("Canvas/ButtonItemPickItem");
        UIController[2] = GameObject.Find("Canvas/ButtonItemSlot1");
        UIController[3] = GameObject.Find("Canvas/ButtonItemSlot2");
        UIController[4] = GameObject.Find("Canvas/HealthBar");
        UIController[5] = GameObject.Find("Canvas/SanityBar");
        UIController[6] = GameObject.Find("Canvas/TotalMemory");
        UIController[7] = GameObject.Find("Canvas/ButtonSettings");

        // UIController[8] = GameObject.Find("Canvas/ButtonTurnBack");
        // UIController[9] = GameObject.Find("Canvas/PanelRespawn");
        // UIController[10] = GameObject.Find("Canvas/PanelSettings");



        speedSlider = UIController[1].GetComponent<Slider>();

        UiHidePlace = GameObject.Find("Canvas/UIHidePlace").GetComponent<RectTransform>();

        for (int i = 0; i < UIController.Length; i++)
        {
            if (UIController[i] != null)
            {
                RectTransform rectTransform = UIController[i].GetComponent<RectTransform>();
                currentRectTransforms.Add(rectTransform);
                originalPositions.Add(rectTransform.position);
            }
        }


        UIPocongJumscare = GameObject.Find("Canvas/pocongJumpscare");
        UIPocongJumscare.SetActive(false);

        // currentRectTransforms[8].position = UiHidePlace.position;
        // currentRectTransforms[9].position = UiHidePlace.position;
        // currentRectTransforms[10].position = UiHidePlace.position;
    }

    public void TriggerJumpscarePocong()
    {
        StartCoroutine(JumpscarePocong());
    }

    private IEnumerator JumpscarePocong()
    {

        // Geser masing-masing UI keluar dari layar
        for (int i = 0; i < UIController.Length; i++)
        {
            if (UIController[i] != null)
            {
                currentRectTransforms[i].position = UiHidePlace.position;
            }
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
                if (UIController[i] != null)
                {
                    currentRectTransforms[i].position = originalPositions[i];
                }
            }
        }
        else if (mainCharacterHealth.currentHealth <= 0f)
        {
            mainCharacterHealth.MainCharacterDead();
        }
    }
}