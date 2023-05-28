using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public InventoryUI inventoryUI;

    private void Start()
    {
        if (inventoryUI == null)
        {
            Debug.LogError("InventoryUI no está asignado en el componente InventorySystem.");
        }
    }

    public bool AddItem(Item item)
    {
        items.Add(item);
        inventoryUI.Refresh();
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        inventoryUI.Refresh();
    }
}


