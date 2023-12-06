using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterController : MonoBehaviour
{
    public Slider speedSlider;
    public Button TurnBackButton;
    public float walkSpeed = 7f;
    public float runSpeed = 15f;
    public float backwardSpeed = 5f;
    private bool isSliderPressed = false;
    private float sliderValue;
    public bool isFlip;
    private Animator baseCharacterAnimator;
    private MainCharacterAnimation mainCharacterAnimation;
    private MainCharacterHealth mainCharacterHealth;
    private MainCharacterSanity mainCharacterSanity;

    

    private void Start()
    {
        mainCharacterHealth = GetComponent<MainCharacterHealth>();
        mainCharacterSanity = GetComponent<MainCharacterSanity>();

        baseCharacterAnimator = GetComponentInChildren<Animator>();
        mainCharacterAnimation = GetComponentInChildren<MainCharacterAnimation>();
        speedSlider.onValueChanged.AddListener(HandleSliderValueChanged);
        isFlip = false;

    }

    void TakeDamage(float damage)
    {
        mainCharacterHealth.TakeDamage(damage);
    }

    void LoseSanity(float sanityLoss)
    {
        mainCharacterSanity.LoseSanity(sanityLoss);
    }


    private void Update()
    {

        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        sliderValue = speedSlider.value;
        if (isSliderPressed && isFlip == false)
        {
            // Pemrosesan pergerakan sesuai nilai slider jika slider ditekan
            if (sliderValue > 0.5f)
            {
                baseCharacterAnimator.SetFloat("isMovingForward", sliderValue);
                MovePlayer(walkSpeed);
            }
            else if (sliderValue > 1f)
            {
                baseCharacterAnimator.SetFloat("isMovingForward", sliderValue);
                MovePlayer(runSpeed);
            }
            else if (sliderValue < -0.25f)
            {
                baseCharacterAnimator.SetFloat("isMovingBackward", sliderValue);
                MovePlayer(-backwardSpeed);
            }
            else
            {
                StopPlayer();
            }
        }
        else if (isSliderPressed && isFlip)
        {
            // Pemrosesan pergerakan sesuai nilai slider jika slider ditekan
            if (sliderValue > 0.5f)
            {
                baseCharacterAnimator.SetFloat("isMovingForward", sliderValue);
                MovePlayer(-walkSpeed);
            }
            else if (sliderValue > 1f)
            {
                baseCharacterAnimator.SetFloat("isMovingForward", sliderValue);
                MovePlayer(-runSpeed);
            }
            else if (sliderValue < -0.25f)
            {
                baseCharacterAnimator.SetFloat("isMovingBackward", sliderValue);
                MovePlayer(backwardSpeed);
            }
            else
            {

                StopPlayer();
            }
        }
        else
        {

            // Pemrosesan ketika slider tidak lagi ditekan (di-release)
            StopPlayer();
        }
    }

    private void MovePlayer(float speed)
    {

        Vector3 movement = new Vector3(2, 0f, 0f).normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void StopPlayer()
    {
        // Implementasi berhenti atau animasi berhenti jika diperlukan
        baseCharacterAnimator.SetFloat("isMovingForward", sliderValue);
        baseCharacterAnimator.SetFloat("isMovingBackward", sliderValue);
    }
    public void HandleButtonTurnBackValueChanged()
    {
        if (isFlip)
        {
            isFlip = false;
        }
        else
        {
            isFlip = true;
        }
        mainCharacterAnimation.FlipScale(isFlip);

        // Event ini dipanggil setiap kali nilai slider berubah
    }

    private void HandleSliderValueChanged(float value)
    {

        // Event ini dipanggil setiap kali nilai slider berubah
        // Di sini, Anda dapat menanggapi perubahan nilai atau menetapkan status isSliderPressed
        isSliderPressed = Mathf.Approximately(value, 0.0f) == false;
    }
}
