using UnityEngine;
using System.Collections.Generic;

public class ShapeData : MonoBehaviour
{
    public Vector2Int[] cells;
    public float cellSize = 100f;

    void Awake()
    {
        List<Vector2Int> list = new List<Vector2Int>();

        foreach (Transform child in transform)
        {
            RectTransform rt = child as RectTransform;
            if (rt == null) continue;

            int x = Mathf.RoundToInt(rt.anchoredPosition.x / cellSize);
            int y = Mathf.RoundToInt(-rt.anchoredPosition.y / cellSize);

            list.Add(new Vector2Int(x, y));
        }

        cells = list.ToArray();
    }
}