using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Tombol yang terkait dengan slot
    public Button button;

    // Item yang ditugaskan ke slot
    private Item assignedItem;

    public Item AssignedItem
    {
        get { return assignedItem; }
        set { assignedItem = value; }
    }

    // Properti boolean untuk mengecek apakah slot kosong
    public bool IsEmpty => assignedItem == null;

    // Referensi ke komponen MainCharacterHealth
    private MainCharacterHealth mainCharacterHealth;

    // Waktu yang harus ditahan untuk menjatuhkan item
    private float holdTime = 1.0f;

    // Variabel untuk mendeteksi apakah tombol ditekan
    private bool held = false;

    // Variabel untuk menghitung jumlah klik
    private int clickCount = 0;

    // Waktu maksimum antara dua klik untuk mengenali klik ganda
    private float clickDelay = 0.5f;

    // Waktu dari klik terakhir
    private float lastClickTime = 0f;

    // Dipanggil saat awal permainan
    void Start()
    {
        // Menambahkan listener ke tombol
        button.onClick.AddListener(() => {
            // Mengecek apakah ada item yang diassign dan bukan null
            if (assignedItem != null)
            {
                clickCount++;

                if (clickCount == 1)
                {
                    lastClickTime = Time.time;
                }

                if (clickCount > 1 && Time.time - lastClickTime < clickDelay)
                {
                    // Logika penggunaan item sesajen
                    if (assignedItem != null && assignedItem is ItemSesajen)
                    {
                        // Simpan referensi ke item sebelum memanggil Use()
                        ItemSesajen sesajenItem = (ItemSesajen)assignedItem;
                        
                        // Coba gunakan item
                        sesajenItem.Use();
                        
                        // Periksa jika item berhasil digunakan dan pocong diusir
                        if (sesajenItem.HasBeenUsedSuccessfully)
                        {
                            // Hanya clear slot jika item berhasil digunakan
                            ClearSlot();
                        }
                    }
                    // Logika penggunaan item HP
                    else if (assignedItem is ItemHP)
                    {
                        MainCharacterHealth health = FindObjectOfType<MainCharacterHealth>();
                        // Mengecek apakah kesehatan tidak penuh
                        if (health.GetCurrentHealth() < health.maxHealth)
                        {
                            // Pemanggilan metode Use() spesifik untuk item HP
                            assignedItem.Use();
                            ClearSlot();
                        }
                        else
                        {
                            Debug.Log("Health is full, cannot use HP item.");
                        }
                    }

                    // Reset jumlah klik
                    clickCount = 0;
                }
                else if (Time.time - lastClickTime > clickDelay)
                {
                    // Reset jika waktu antara klik terlalu lama
                    clickCount = 1;
                    lastClickTime = Time.time;
                }
            }
            else
            {
                Debug.Log("No item assigned to this slot, cannot use.");
            }
        });
    }


    // Dipanggil setiap frame
    public void Update()
    {
        // Menangani penahanan tombol
        if (held && !IsEmpty)
        {
            button.interactable = false;
            held = false;
            DropItem();
        }
    }

    // Dipanggil saat tombol ditekan
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            StartCoroutine(HoldTimer());
        }
    }

    // Dipanggil saat tombol dilepas
    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
        held = false;
    }

    // Coroutine untuk menghitung waktu penahanan tombol
    private IEnumerator HoldTimer()
    {
        yield return new WaitForSeconds(holdTime);
        held = true;
    }

    // Melepaskan item dari inventori
    private void DropItem()
    {
        assignedItem.Drop();
        ClearSlot();
    }

    // Menugaskan item ke slot
    public void AssignItem(Item item)
    {
        AssignedItem = item;
        assignedItem = item;
        button.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        button.interactable = true;
    }

    // Dipanggil saat tombol slot di klik
    public void OnSlotButtonClicked()
    {
        if (assignedItem != null)
        {
            Debug.Log("Trying to use item: " + assignedItem.itemName);

            // Mengecek apakah item adalah ItemHP
            if (assignedItem is ItemHP)
            {
                assignedItem.Use();
                Debug.Log("Used HP item.");
            }
            else
            {
                Debug.Log("The assigned item is not an HP item, will not use.");
            }
            ClearSlot();
        }
        else
        {
            Debug.Log("No item assigned to this slot, cannot use.");
        }
    }

    // Membersihkan slot
    public void ClearSlot()
    {
        // Memastikan bahwa listener dihapus saat slot dibersihkan
        if (assignedItem != null && assignedItem is ItemHP)
        {
            button.onClick.RemoveListener(assignedItem.Use);
        }

        assignedItem = null;
        button.interactable = false;
        button.GetComponent<Image>().sprite = null;
    }
}
