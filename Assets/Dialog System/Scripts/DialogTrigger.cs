using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogTrigger : MonoBehaviour
{    
    public DialogManager dialogManager; // Referensi ke Dialog Manager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogManager.StartDialog(); // Panggil method StartDialog pada Dialog Manager
        }
    }


}
