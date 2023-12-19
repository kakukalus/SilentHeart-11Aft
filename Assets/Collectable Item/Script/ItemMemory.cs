using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ItemMemory : MonoBehaviour
{
    public TextMeshProUGUI collectionText;
    public static event Action<string> OnItemCollected;
    public string itemMemoryID; // Unique identifier for each item.
    public string[] dialogOnPickup;
    public DialogManager dialogManager;
    public PickButton pickButton;

    private bool isPickedUp = false;

    private void Start()
    {
        // Check if the item is already collected based on the unique identifier.
        if (PlayerPrefs.GetInt(itemMemoryID, 0) == 1)
        {
            isPickedUp = true;
            gameObject.SetActive(false);
        }
        else
        {
            isPickedUp = false;
        }

        // UpdateCollectionTextOnStart();
    }

    public void PickUp()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
            PlayerPrefs.SetInt(itemMemoryID, 1);
            PlayerPrefs.Save();

            OnItemCollected?.Invoke(itemMemoryID);

            UpdateCollectionText();
            Debug.Log($"Collected memory: {itemMemoryID}");

            if (dialogOnPickup.Length > 0 && dialogManager != null)
            {
                dialogManager.StartDialog(dialogOnPickup);
            }
            else
            {
                Debug.LogWarning($"No dialog is set for {itemMemoryID} or DialogManager is not assigned.");
            }

            gameObject.SetActive(false);
        }
    }

    private void UpdateCollectionText()
    {
        if (collectionText != null)
        {
            int currentCount = int.Parse(collectionText.text);
            currentCount++;
            collectionText.text = currentCount.ToString();

            PlayerPrefs.SetInt("TotalCollectedItems", currentCount);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("Collection Text is not set on " + gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            if (pickButton != null)
            {
                pickButton.EnableButton();
                pickButton.GetComponent<Button>().onClick.AddListener(PickUp);
            }
            else
            {
                Debug.LogError("PickButton is not assigned in the inspector.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickButton != null)
            {
                pickButton.DisableButton();
                pickButton.GetComponent<Button>().onClick.RemoveListener(PickUp);
            }
            else
            {
                Debug.LogError("PickButton is not assigned in the inspector.");
            }
        }
    }

    private void UpdateCollectionTextOnStart()
    {
        int totalCollectedItems = PlayerPrefs.GetInt("TotalCollectedItems", 0);
        if (collectionText != null)
        {
            collectionText.text = totalCollectedItems.ToString();
        }
        else
        {
            Debug.LogError("Collection Text is not set in the inspector.");
        }
    }

    public void ResetGame()
    {
        // Reset PlayerPrefs data for the specific item.
        PlayerPrefs.SetInt(itemMemoryID, 0);
        PlayerPrefs.SetInt("TotalCollectedItems", 0);
        PlayerPrefs.Save();

        UpdateCollectionTextOnStart();
    }
}
