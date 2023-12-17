using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Transform pemain yang akan diikuti oleh musuh
    public Transform playerTransform;

    // Kecepatan gerak musuh
    public float moveSpeed = 5f;

    // Jarak vertikal dari musuh ke pemain (dapat diatur dari Unity Inspector)
    public float verticalOffset;

    // Memanggil setiap frame
    private void Update()
    {
        // Memanggil fungsi untuk mengikuti pemain
        FollowPlayer();
    }

    // Mengikuti pemain dengan mempertimbangkan arah dan offset
    private void FollowPlayer()
    {
        if (playerTransform != null)
        {
            // Menghitung arah dari musuh ke pemain pada sumbu x dan y
            float xDirection = playerTransform.position.x - transform.position.x;

            // Menghadap ke pemain pada sumbu x
            if (xDirection > 0 && !FacingRight())
            {
                Flip();
            }
            else if (xDirection < 0 && FacingRight())
            {
                Flip();
            }

            // Bergerak menuju pemain pada sumbu x dan y dengan mempertimbangkan offset
            Vector3 targetPosition = new Vector2(playerTransform.position.x, playerTransform.position.y + verticalOffset);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    // Memeriksa apakah musuh menghadap ke kanan
    private bool FacingRight()
    {
        return transform.localScale.x < 0;
    }

    // Memutar musuh
    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
