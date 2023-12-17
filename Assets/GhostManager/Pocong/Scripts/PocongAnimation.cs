using UnityEngine;

public class PocongAnimation : MonoBehaviour
{
    private Vector3 defaultScale;
    private Vector3 currentScale;

    private void Start()
    {
        defaultScale = transform.localScale;
        currentScale = defaultScale;
        currentScale.x = -currentScale.x;

    }
    public void FlipScale(bool flip)
    {
        // Mengubah arah wajah musuh dengan membalikkan skala di sumbu X
        Vector3 newScale = transform.localScale;
        newScale.x = flip ? Mathf.Abs(newScale.x) : -Mathf.Abs(newScale.x);
        transform.localScale = newScale;
    }
}
