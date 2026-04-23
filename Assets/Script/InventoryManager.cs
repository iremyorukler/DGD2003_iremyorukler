using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Envanter Verisi")]
    public List<string> collectedItems = new List<string>();

    [Header("Görsel Arayüz (UI)")]
    public Image[] slotIcons;

    public Sprite tokenSprite;

    void Start()
    {
        foreach (Image icon in slotIcons)
        {
            icon.sprite = null;
            icon.color = new Color(1, 1, 1, 0); 
        }
    }

    public void AddItem(string itemName)
    {
        collectedItems.Add(itemName);

        for (int i = 0; i < slotIcons.Length; i++)
        {
            if (slotIcons[i].sprite == null) 
            {
                if (itemName == "Token")
                {
                    slotIcons[i].sprite = tokenSprite;
                    slotIcons[i].color = new Color(1, 1, 1, 1);
                }

                break; 
            }
        }
    }
}