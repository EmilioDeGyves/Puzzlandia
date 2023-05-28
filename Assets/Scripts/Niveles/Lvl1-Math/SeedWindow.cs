using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedWindow : MonoBehaviour
{
    private InventorySystem inventorySystem;
    public GameObject plant; // GameObject que queremos activar

    private void Start()
    {
        // Obtenemos la referencia al sistema de inventario en el jugador
        inventorySystem = GetComponent<InventorySystem>();
        if (inventorySystem == null)
        {
            Debug.LogError("No se encuentra InventorySystem en el componente jugador.");
        }

        if (plant == null)
        {
            Debug.LogError("Plant GameObject no está asignado en el componente SeedingSystem.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dirt")
        {
            foreach (Item item in inventorySystem.items)
            {
                if (item.itemName == "Semillas")
                {
                    plant.SetActive(true); // Activa el GameObject planta
                    break;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dirt")
        {
            plant.SetActive(false); // Desactiva el GameObject planta
        }
    }
}
