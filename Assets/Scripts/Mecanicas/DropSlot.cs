using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public bool IsOccupied { get; private set; }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem item = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (item != null && !IsOccupied)
        {
            IsOccupied = true;
            GameObject droppedItem = Instantiate(item.itemPrefab, transform.position, Quaternion.identity, transform);
            droppedItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            Destroy(item.gameObject);
        }
    }
}