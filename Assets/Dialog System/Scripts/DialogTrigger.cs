using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogManager dialogManager;
    private bool hasBeenTriggered = false;
    public string triggerId; // ID unik untuk setiap DialogTrigger
    public string[] dialogSentences; // Kalimat-kalimat untuk dialog ini
    
    public bool HasBeenTriggered
    {
        get { return hasBeenTriggered; }
        set { hasBeenTriggered = value; }
    }

    private void Start()
    {
        LoadTriggerStatus();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasBeenTriggered)
        {
            Debug.Log("Dialog triggered: " + string.Join(", ", dialogSentences));
            dialogManager.StartDialog(dialogSentences); // Mengirim dialog ke manager
            hasBeenTriggered = true;
            SaveTriggerStatus();
        }
    }

    public void ResetTrigger()
    {
        hasBeenTriggered = false;
        SaveTriggerStatus();
    }

    private void SaveTriggerStatus()
    {
        PlayerPrefs.SetInt("DialogTrigger_" + triggerId, hasBeenTriggered ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadTriggerStatus()
    {
        hasBeenTriggered = PlayerPrefs.GetInt("DialogTrigger_" + triggerId, 0) == 1;
    }

    public void TriggerDialog()
    {
        if(dialogSentences.Length > 0)
        {
            dialogManager.StartDialog(dialogSentences);
        }
        else
        {
            Debug.LogError("Dialog sentences are empty for trigger ID: " + triggerId);
        }
    }

}
