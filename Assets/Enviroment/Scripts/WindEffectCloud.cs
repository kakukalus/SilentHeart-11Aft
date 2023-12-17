using UnityEngine;

public class WindEffectCloud : MonoBehaviour
{
    public float windSpeed = 5f;

    void Update()
    {
        // Menggerakkan pohon ke kanan
        transform.Translate(Vector3.right * windSpeed * Time.deltaTime);

        // Jika pohon melewati batas tertentu, reset posisi ke kiri layar
        if (transform.position.x > Screen.width)
        {
            float randomY = Random.Range(0f, Screen.height);  // Pilih posisi Y acak
            transform.position = new Vector3(-Screen.width, randomY, 0f);
        }
    }
}
