using UnityEngine;

public class MainCharacterCamera : MonoBehaviour
{
    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    private MainCharacterController mainCharacterController;
    void Start()
    {
        targetPos = transform.position;
        mainCharacterController = target.GetComponent<MainCharacterController>();
    }

    void FixedUpdate()
    {
        if (mainCharacterController.isFlip)
        {
            offset.x = -6;
        }
        else if (mainCharacterController.isFlip == false)
        {
            offset.x = 6;
        }

        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            // Mengurangi kecepatan interpolasi agar pergerakan kamera lebih halus
            interpVelocity = targetDirection.magnitude * 5f;

            // Mengatur posisi targetPos lebih ke depan karakter
            targetPos = target.transform.position - (targetDirection.normalized * followDistance);

            // Menyimpan posisi Z kamera sebelum dilakukan perubahan
            float currentZ = transform.position.z;

            // Menyusun ulang posisi kamera dengan kecepatan interpolasi yang lebih rendah
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.1f);

            // Menetapkan kembali posisi Z kamera
            transform.position = new Vector3(transform.position.x, transform.position.y, currentZ);
        }
    }
}
