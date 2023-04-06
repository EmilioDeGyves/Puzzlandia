using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform RT;
    private CanvasGroup CanvaG;
    public GameObject Objeto;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
        CanvaG = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        Objeto.SetActive(true);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown/agarra el puntero");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag/Empieza a arrasrar");
        CanvaG.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag/arrasrar");
        RT.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag/Termina de arratrar");
        CanvaG.blocksRaycasts = true;
    }
}

