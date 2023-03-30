using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventorySystem inventory;
    public Image[] itemSlots;
    public Sprite emptySlotSprite;

    public void Refresh()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                itemSlots[i].sprite = inventory.items[i].itemIcon;
            }
            else
            {
                itemSlots[i].sprite = emptySlotSprite;
            }
        }
    }
}
