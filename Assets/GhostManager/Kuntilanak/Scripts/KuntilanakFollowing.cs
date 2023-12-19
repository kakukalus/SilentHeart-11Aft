using System;
using UnityEngine;

public class KuntilanakFollowing : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingDistance = 2f;

    private Transform player;
    private Animator basekuntilanakAnimator;
    // private BaseCharacter kuntilanakAnimation;
    public bool isChase;

    // private KuntilanakAnimation kuntilanakAnimation;
    public float facingThreshold = 0.1f;  // Ambang batas untuk menentukan arah wajah

    void Start()
    {
        isChase = false;
        // Menemukan referensi ke pemain (dalam hal ini, kita mengasumsikan pemain ada dalam scene)
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // get component from children
        basekuntilanakAnimator = GetComponentInChildren<Animator>();
        // kuntilanakAnimation = GetComponentInChildren<BaseCharacter>();
    }

    // void Update()
    // {
    //     // Pastikan pemain ditemukan sebelum mencoba mengejar
    //     if (player != null && isChase == true)
    //     {
    //         basekuntilanakAnimator.SetBool("isChased", true);
    //         // Mendapatkan posisi relatif pemain terhadap musuh
    //         float relativePosition = player.position.x - transform.position.x;

    //         // Mengubah arah wajah musuh berdasarkan posisi relatif
    //         if (Mathf.Abs(relativePosition) > facingThreshold)
    //         {
    //             // Player berada di sebelah kanan musuh
    //             if (relativePosition > 0)
    //             {
    //                 kuntilanakAnimation.FlipScale(true);  // Menghadap kanan
    //             }
    //             // Player berada di sebelah kiri musuh
    //             else
    //             {
    //                 kuntilanakAnimation.FlipScale(false);  // Menghadap kiri
    //             }
    //         }


    //         // Hitung vektor arah dari musuh ke pemain
    //         Vector3 direction = player.position - transform.position;

    //         // Jika pemain berada di luar jarak berhenti, gerakkan musuh
    //         if (direction.magnitude > stoppingDistance)
    //         {
    //             basekuntilanakAnimator.SetBool("isChased", true);

    //             // Normalisasi vektor arah untuk mendapatkan arah tanpa memperhatikan panjangnya
    //             Vector3 normalizedDirection = direction.normalized;

    //             // Pemindahan musuh ke arah pemain
    //             transform.Translate(normalizedDirection * speed * Time.deltaTime);
    //         }
    //     }
    // }

    // public void DestroyThis()
    // {
    //     Destroy(gameObject);
    // }
}
