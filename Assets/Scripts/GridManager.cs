using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public RectTransform gridRect;
    public int gridSize = 6;
    public float cellSize;

    private bool[,] occupied;

    void Awake()
    {
        instance = this;
        gridRect = GetComponent<RectTransform>();
        cellSize = gridRect.rect.width / gridSize;
        occupied = new bool[gridSize, gridSize];
    }

    public Vector2Int GetCellFromScreenPoint(Vector2 screenPos)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(gridRect, screenPos, null, out Vector2 local);

        float startX = -gridRect.rect.width / 2 + cellSize / 2;
        float startY = gridRect.rect.height / 2 - cellSize / 2;

        int col = Mathf.RoundToInt((local.x - startX) / cellSize);
        int row = Mathf.RoundToInt((startY - local.y) / cellSize);

        return new Vector2Int(col, row);
    }

    public Vector3 GetWorldPosFromCell(Vector2Int cell)
    {
        float startX = -gridRect.rect.width / 2 + cellSize / 2;
        float startY = gridRect.rect.height / 2 - cellSize / 2;

        Vector2 local = new Vector2(startX + cell.x * cellSize, startY - cell.y * cellSize);
        return gridRect.TransformPoint(local);
    }

    public bool IsValidCell(Vector2Int cell)
    {
        return cell.x >= 0 && cell.x < gridSize && cell.y >= 0 && cell.y < gridSize;
    }

    public bool CanPlace(Vector2Int origin, Vector2Int[] shapeCells)
    {
        foreach (var offset in shapeCells)
        {
            Vector2Int c = origin + offset;
            if (!IsValidCell(c)) return false;
            if (occupied[c.x, c.y]) return false;
        }
        return true;
    }

    public void PlaceShape(Vector2Int origin, Vector2Int[] shapeCells)
    {
        foreach (var offset in shapeCells)
        {
            Vector2Int c = origin + offset;
            occupied[c.x, c.y] = true;
        }
    }
}