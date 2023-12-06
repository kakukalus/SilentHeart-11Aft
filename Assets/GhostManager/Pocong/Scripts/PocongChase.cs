using UnityEngine;

public class PocongChase : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingDistance = 2f;

    private Transform player;

    void Start()
    {
        // Menemukan referensi ke pemain (dalam hal ini, kita mengasumsikan pemain ada dalam scene)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Pastikan pemain ditemukan sebelum mencoba mengejar
        if (player != null)
        {
            // Hitung vektor arah dari musuh ke pemain
            Vector3 direction = player.position - transform.position;

            // Jika pemain berada di luar jarak berhenti, gerakkan musuh
            if (direction.magnitude > stoppingDistance)
            {
                // Normalisasi vektor arah untuk mendapatkan arah tanpa memperhatikan panjangnya
                Vector3 normalizedDirection = direction.normalized;

                // Pemindahan musuh ke arah pemain
                transform.Translate(normalizedDirection * speed * Time.deltaTime);
            }
        }
    }
}
