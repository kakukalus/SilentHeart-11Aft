using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button button; // Tombol yang terkait dengan slot
    private Item assignedItem; // Item yang ditugaskan ke slot

    public Item AssignedItem
    {
        get { return assignedItem; }
        set { assignedItem = value; }
    }

    public bool IsEmpty => assignedItem == null; // Cek apakah slot kosong

    private MainCharacterHealth mainCharacterHealth; // Referensi ke kesehatan karakter utama
    private float holdTime = 1.0f; // Waktu penahanan untuk menjatuhkan item
    private bool held = false; // Apakah tombol sedang ditekan

    private int clickCount = 0; // Jumlah klik
    private float clickDelay = 0.5f; // Waktu maksimum antara dua klik untuk deteksi klik ganda
    private float lastClickTime = 0f; // Waktu dari klik terakhir

    void Start()
    {
        // Menambahkan listener ke event onClick dari tombol.
        button.onClick.AddListener(() => {
            // Periksa jika ada item yang ditugaskan ke slot ini.
            if (assignedItem != null)
            {
                // Menambahkan jumlah klik.
                clickCount++;

                // Jika ini adalah klik pertama, catat waktu klik tersebut.
                if (clickCount == 1)
                {
                    lastClickTime = Time.time;
                }

                // Jika ini adalah klik kedua atau lebih, dan terjadi dalam waktu yang singkat setelah klik pertama,
                // maka anggap ini sebagai double-click.
                if (clickCount > 1 && Time.time - lastClickTime < clickDelay)
                {
                    // Jalankan logika penggunaan item.
                    UseItem();
                    // Reset jumlah klik setelah penggunaan item.
                    clickCount = 0;
                }
                else if (Time.time - lastClickTime > clickDelay)
                {
                    // Jika waktu antara klik terlalu lama, reset klik menjadi satu dan catat waktu klik ini.
                    clickCount = 1;
                    lastClickTime = Time.time;
                }
            }
            else
            {
                // Jika tidak ada item di slot ini, tampilkan log.
                Debug.Log("Tidak ada item di slot ini.");
            }
        });
    }


    // Metode yang dipanggil per frame untuk menangani penahanan tombol
    public void Update()
    {
        if (held && !IsEmpty)
        {
            button.interactable = false;
            held = false;
            DropItem();
        }
    }

    // Menangani klik tombol
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            StartCoroutine(HoldTimer());
        }
    }

    // Menangani pelepasan tombol
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
        // AssignedItem = item;
        assignedItem = item;
        button.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        button.interactable = true;
    }

    // Metode untuk membersihkan slot
    public void ClearSlot()
    {
        assignedItem = null;
        button.interactable = false;
        button.GetComponent<Image>().sprite = null;
    }

    // Logika penggunaan item
    private void UseItem()
    {
        if (assignedItem is ItemHP)
        {
            assignedItem.Use();
            ClearSlot();
        }
        else if (assignedItem is ItemSesajen)
        {
            assignedItem.Use();
            if (((ItemSesajen)assignedItem).HasBeenUsedSuccessfully)
            {
                ClearSlot();
            }
        }
        else
        {
            Debug.Log("Tipe item tidak dikenali.");
        }
    }
}
