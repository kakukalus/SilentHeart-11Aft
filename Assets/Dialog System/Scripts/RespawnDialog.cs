using UnityEngine;

public class RespawnDialog : DialogTrigger
{
     public Vector2 respawnPosition; // Koordinat untuk respawn pemain setelah dialog
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !HasBeenTriggered)
        {
            // Memulai dialog seperti biasa
            dialogManager.StartDialog(dialogSentences); // Mengirim dialog ke manager
            HasBeenTriggered = true;
            SaveTriggerStatus();

            // Memindahkan pemain ke koordinat respawn yang telah ditentukan
            collision.transform.position = respawnPosition;
            Debug.Log($"Pemain telah direspawn di lokasi yang ditentukan: {respawnPosition}");
        }
    }
}
