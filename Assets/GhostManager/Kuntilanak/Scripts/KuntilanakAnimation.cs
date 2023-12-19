using UnityEngine;

public class KuntilanakAnimation : MonoBehaviour
{
    private Vector3 defaultScale;
    private Vector3 currentScale;

    private void Start()
    {
        defaultScale = transform.localScale;
        currentScale = defaultScale;
        currentScale.x = -currentScale.x;
        // Mendapatkan nilai acak antara 0 dan 1
        float randomValue = Random.Range(0f, 1f);

        // Mengecek apakah nilai acak di atas atau di bawah 0.5
        if (randomValue < 0.5f)
        {
            FlipScale(true);
        }
    }
    public void FlipScale(bool flip)
    {
        // Mengubah arah wajah musuh dengan membalikkan skala di sumbu X
        Vector3 newScale = transform.localScale;
        newScale.x = flip ? Mathf.Abs(newScale.x) : -Mathf.Abs(newScale.x);
        transform.localScale = newScale;
    }
}
