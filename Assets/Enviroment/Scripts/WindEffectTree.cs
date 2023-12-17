using UnityEngine;

public class WindEffectTree : MonoBehaviour
{
    public float maxRotationAngle = 6f; // Maksimum sudut rotasi
    public float windSpeed;
    private Vector3 pivotPoint; // Titik pivot
    private float currentRotation = 0f;

    void Start()
    {
        // Tentukan pivot sebagai posisi di atas objek
        pivotPoint = new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);
        windSpeed = Random.Range(-2f, 2f);

    }

    void Update()
    {
        // Menghitung rotasi berdasarkan waktu dan kecepatan angin
        float rotationAmount = Mathf.Sin(Time.time * windSpeed) * maxRotationAngle * Time.deltaTime;

        // Menambahkan rotasi ke rotasi saat ini
        currentRotation += rotationAmount;

        // Batasi agar tidak melebihi 360 derajat
        currentRotation = Mathf.Clamp(currentRotation, 0f, 360f);

        // Mengatur rotasi objek
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, currentRotation));
    }
}
