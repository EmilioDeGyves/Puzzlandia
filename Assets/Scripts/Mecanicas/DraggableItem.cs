using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject itemPrefab;
    private GameObject draggedInstance;
    private Canvas canvas;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (itemPrefab != null)
        {
            draggedInstance = Instantiate(itemPrefab, canvas.transform);
            draggedInstance.transform.SetAsLastSibling();
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
            if (slot != null)
            {
                slot.OnDrop(draggedInstance);
            }
            else
            {
                Destroy(draggedInstance);
            }
        }
    }

    private void UpdateDraggedItemPosition(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
        draggedInstance.transform.localPosition = localPoint;
    }
}