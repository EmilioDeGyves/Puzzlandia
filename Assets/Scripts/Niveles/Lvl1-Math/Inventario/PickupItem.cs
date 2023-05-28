using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item;
    public string playerTag = "Player";
    public GameConroller GC;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            InventorySystem inventory = other.GetComponent<InventorySystem>();
            if (inventory != null && inventory.AddItem(item))
            {
                
                GC.ResetGame(); // Llamar a ResetGame() en el inicio para inicializar los números aleatorios
                Destroy(gameObject);
            }
        }
    }
}

