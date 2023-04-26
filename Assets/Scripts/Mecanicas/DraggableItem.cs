using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject itemPrefab;
    private GameObject draggedInstance;
    private RectTransform canvasRectTransform;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemPrefab != null)
        {
            draggedInstance = Instantiate(itemPrefab, transform.position, Quaternion.identity, FindObjectOfType<Canvas>().transform);
            draggedInstance.transform.SetAsLastSibling();
            canvasRectTransform = draggedInstance.GetComponent<RectTransform>();
            UpdateDraggedItemPosition(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedInstance != null)
        {
            UpdateDraggedItemPosition(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (draggedInstance != null)
        {
            DropSlot slot = eventData.pointerCurrentRaycast.gameObject?.GetComponent<DropSlot>();
            if (slot != null && !slot.IsOccupied)
            {
                slot.OnDrop(eventData);
            }
            else
            {
                Destroy(draggedInstance);
            }
        }
    }

    private void UpdateDraggedItemPosition(PointerEventData eventData)
    {
        RectTransform canvasRectTransform = draggedInstance.transform.parent.GetComponent<RectTransform>();
        Vector2 anchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, eventData.pressEventCamera, out anchoredPosition);
        draggedInstance.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }
}
