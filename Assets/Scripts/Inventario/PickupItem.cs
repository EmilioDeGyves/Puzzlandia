using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item;
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            InventorySystem inventory = other.GetComponent<InventorySystem>();
            if (inventory != null && inventory.AddItem(item))
            {
                Destroy(gameObject);
            }
        }
    }
}

