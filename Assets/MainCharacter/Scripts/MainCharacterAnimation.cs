using UnityEngine;

public class MainCharacterAnimation : MonoBehaviour
{
    private Vector3 defaultScale;
    private Vector3 currentScale;

    private void Start()
    {
        defaultScale = transform.localScale;
        currentScale = defaultScale;
        currentScale.x = -currentScale.x;

    }
    private void Update()
    {
    }

    public void FlipScale(bool flip)
    {
        if (flip == false)
        {
            transform.localScale = defaultScale;
        }
        if (flip)
        {
            transform.localScale = currentScale;
        }
    }
}
