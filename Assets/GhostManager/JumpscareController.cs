
using System.Collections;
using UnityEngine;

public class JumpscareController : MonoBehaviour
{
    public GameObject jumpscareImage;
    public float jumpscareDuration = 3f;
    public GameObject[] uiCanvases;
    void Start()
    {
        jumpscareImage.SetActive(false);
    }

    public void TriggerJumpScare()
    {
        StartCoroutine(TriggerJumpscare());
    }


    private IEnumerator TriggerJumpscare()
    {
        // Sembunyikan semua UI

        foreach (GameObject canvas in uiCanvases)
        {
            canvas.gameObject.SetActive(false);
        }

        // Tampilkan gambar jumpscare
        jumpscareImage.SetActive(true);

        // Tunggu beberapa detik
        yield return new WaitForSeconds(jumpscareDuration);

        // Sembunyikan gambar jumpscare
        jumpscareImage.SetActive(false);

        // Munculkan kembali UI
        foreach (GameObject canvas in uiCanvases)
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
