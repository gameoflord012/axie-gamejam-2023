using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class Board : MonoBehaviour
{
    [SerializeField] int minX = -50;
    [SerializeField] int maxX = 50;
    [SerializeField] int minY = -50;
    [SerializeField] int maxY = 50;
    [SerializeField] float step = 0.5f;

    byte[,] grid;

    Vector2Int WorldPosToGrid(Vector2 worldPos)
    {
        return new Vector2Int((int)(worldPos.x / step), (int)(worldPos.y / step));
    }

    void InitializeBoard()
    {
        foreach(var item in GetComponentsInChildren<BoardItem>())
        {
            var gridPos = WorldPosToGrid(item.transform.position);
            Assert.IsTrue(
                gridPos.x >= minX && gridPos.x <= maxX &&
                gridPos.y >= minY && gridPos.y <= maxY);

            grid[gridPos.x, gridPos.y] = item.GetCost();
        }
    }

    List<BoardItem> GetBoardItems()
    {
        return GetComponentsInChildren<BoardItem>().ToList();
    }

    private void Update()
    {
        Debug.Log(WorldPosToGrid(GetMouseViewPortPos()));
    }

    Vector2 GetMouseViewPortPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Vector2 pos0 = new Vector2();
        Vector2 pos1 = new Vector2();
        for (float i = minX - step; i <= maxX; i += step)
        {
            pos0.x = i;
            pos0.y = minY - step;
            pos1.x = i;
            pos1.y = maxY;

            Gizmos.DrawLine(
                pos0 + new Vector2(step / 2, step / 2),
                pos1 + new Vector2(step / 2, step / 2)
            );
            /*for (int j = 0; j < 100; j++) {

            }*/
        }

        for (float i = minY - step; i <= maxY; i += step)
        {
            pos0.x = minX - step;
            pos0.y = i;
            pos1.x = maxX;
            pos1.y = i;
            Gizmos.DrawLine(
                pos0 + new Vector2(step / 2, step / 2),
                pos1 + new Vector2(step / 2, step / 2)
            );
        }

        foreach(var item in GetBoardItems())
        {
            Gizmos.color = new Color(item.GetCost(), 0, 0);
            Gizmos.DrawSphere(
                (Vector2)WorldPosToGrid(item.transform.position), step / 2);
        }

    }
}
