using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private Vector3 offset;
    private bool isBeingHeld = false;
    private Slot slot;
    private bool isInSlot = false;
    private void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        isBeingHeld = true;
    }

    private void OnMouseDrag()
    {
        if (isBeingHeld)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;

        // Comprueba si la semilla no está en un slot antes de destruirla
        if (slot == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Slot enteredSlot = collision.GetComponent<Slot>();
        if (enteredSlot != null && !isInSlot && !enteredSlot.isActive)
        {
            Debug.Log("Seed entró en un slot");
            
            slot = enteredSlot;
            isInSlot = true;
            slot.AddSeed(this);
            transform.position = slot.transform.position;
        }
        Debug.Log(isInSlot);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Slot exitedSlot = collision.GetComponent<Slot>();
        if (exitedSlot != null && exitedSlot == slot)
        {

            Debug.Log("Seed salió de un slot");
            slot.RemoveSeed(this);
            slot = null;
            isInSlot = false;
        }
        Debug.Log(isInSlot);
    }
}