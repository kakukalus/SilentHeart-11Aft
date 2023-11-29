using UnityEngine;

public class MainCharacterInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        // Implementasi logika interaksi dengan objek atau lingkungan
    }
}
