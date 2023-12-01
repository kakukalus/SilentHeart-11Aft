
using System.Collections;
using UnityEngine;

public class JumpscareController : MonoBehaviour
{
    public GameObject jumpscareImage;
    public float jumpscareDuration = 3f;
    public int = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TriggerJumpscare());
        }
    }

    private IEnumerator TriggerJumpscare()
    {
        // Sembunyikan semua UI
        Canvas[] uiCanvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in uiCanvases)
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
        foreach (Canvas canvas in uiCanvases)
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
