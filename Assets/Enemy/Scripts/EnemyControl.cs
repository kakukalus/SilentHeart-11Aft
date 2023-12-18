using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private MainCharacterHealth mainCharacterHealth;
    // Start is called before the first frame update  private MainCharacterHealth mainCharacterHealth;
    private MainCharacterSanity mainCharacterSanity;

    // Kerusakan saat musuh menyentuh pemain
    public float damageOnHit = 50f;

    // Kerusakan sanity per detik (kerusakan dasar)
    public float sanityDamagePerSecond = 2f;

    // Kerusakan sanity tambahan saat jarak dekat
    public float increasedSanityDamagePerSecond = 5f;

    // Radius untuk kerusakan sanity
    public float damageRadius = 4f;

    void Start()
    {
        // Mendapatkan referensi ke komponen MainCharacterHealth dan MainCharacterSanity
        mainCharacterHealth = FindObjectOfType<MainCharacterHealth>();
        mainCharacterSanity = FindObjectOfType<MainCharacterSanity>();

        // Memulai coroutine untuk menerapkan kerusakan sanity dari waktu ke waktu
        StartCoroutine(ApplySanityDamageOverTime());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Menangani tabrakan dengan pemain
        if (collision.CompareTag("Player"))
        {
            // Memastikan bahwa MainCharacterHealth tidak null sebelum memanggil TakeDamage
            MainCharacterHealth playerHealth = collision.GetComponent<MainCharacterHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageOnHit);
            }
        }
    }


    // Coroutine untuk menerapkan kerusakan sanity dari waktu ke waktu
    private IEnumerator ApplySanityDamageOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // Menunggu selama 1 detik

            // Menghitung jarak ke pemain
            float distanceToPlayer = Vector3.Distance(transform.position, mainCharacterHealth.transform.position);

            // Menerapkan kerusakan sanity berdasarkan jarak
            if (distanceToPlayer <= damageRadius)
            {
                float damage = sanityDamagePerSecond;

                // Meningkatkan kerusakan jika sangat dekat dengan musuh
                if (distanceToPlayer < damageRadius / 2)
                {
                    damage = increasedSanityDamagePerSecond;
                }

                // Memanggil metode LoseSanity pada MainCharacterSanity
                mainCharacterSanity.LoseSanity(damage);
            }
        }
    }
}
