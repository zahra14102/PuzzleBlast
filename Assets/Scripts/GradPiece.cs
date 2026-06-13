using UnityEngine;
using UnityEngine.EventSystems;

public class DragPiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 posisiAwal;
    private ShapeData shapeData;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        shapeData = GetComponent<ShapeData>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        posisiAwal = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rectTransform.position);
        Vector2Int cell = GridManager.instance.GetCellFromScreenPoint(screenPos);

        bool valid = GridManager.instance.IsValidCell(cell);
        bool canPlace = GridManager.instance.CanPlace(cell, shapeData.cells);

        if (canPlace)
        {
            rectTransform.position = GridManager.instance.GetWorldPosFromCell(cell);
            GridManager.instance.PlaceShape(cell, shapeData.cells);
            this.enabled = false;
        }
        else
        {
            rectTransform.anchoredPosition = posisiAwal;
        }
    }
}