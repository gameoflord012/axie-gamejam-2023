using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class Board : MonoBehaviour
{
    [SerializeField] int gridMaxDis = 10;
    [Range(0.1f, 1)]
    [SerializeField] float step = 0.5f;

    byte[,] grid;

    private void Start()
    {
        UpdateBoard();
    }

    float GetStep()
    {
        Assert.IsTrue(step > 0);
        return step;
    }

    public Vector2Int WorldPosToGrid(Vector2 worldPos)
    {
        return new Vector2Int(
            (int)(worldPos.x / GetStep() + gridMaxDis), 
            (int)(worldPos.y / GetStep() + gridMaxDis));
    }

    public Vector2 GridToWorldPos(Vector2Int gridPos)
    {
        return new Vector2(gridPos.x - gridMaxDis + step / 2, gridPos.y - gridMaxDis + step / 2) * step;
    }

    public byte[,] GetBoardGrid()
    {
        return grid;
    }

    public void UpdateBoard()
    {
        int gridSize = gridMaxDis * 2 + 1;
        grid = new byte[gridSize, gridSize];

        for (int i = 0; i < gridSize; i++)
            for (int j = 0; j < gridSize; j++)
                grid[i, j] = 1;

        foreach (var item in GetComponentsInChildren<BoardItem>())
        {
            var gridPos = WorldPosToGrid(item.transform.position);

            if (
                gridPos.x < 0 || gridPos.x >= gridSize &&
                gridPos.y < 0 || gridPos.y >= gridSize)
            {
                Debug.LogWarning(item + " is out if board bound");
                continue;
            }

            grid[gridPos.x, gridPos.y] = item.IsPassable() ? item.GetCost() : (byte)0;
        }
    }

    List<BoardItem> GetBoardItems()
    {
        return GetComponentsInChildren<BoardItem>().ToList();
    }

    private void Update()
    {
        //Debug.Log(WorldPosToGrid(GetMouseViewPortPos()));
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

        float boardMinBound = -gridMaxDis * GetStep();
        float boardMaxBound = gridMaxDis * GetStep();
        for (float i = boardMinBound; i <= boardMaxBound; i += GetStep())
        {
            pos0.x = i;
            pos0.y = boardMinBound;
            pos1.x = i;
            pos1.y = boardMaxBound;

            Gizmos.DrawLine(
                pos0,
                pos1
            );
            /*for (int j = 0; j < 100; j++) {

            }*/
        }

        for (float i = boardMinBound; i <= boardMaxBound; i += GetStep())
        {
            pos0.x = boardMinBound;
            pos0.y = i;
            pos1.x = boardMaxBound;
            pos1.y = i;
            Gizmos.DrawLine(
                pos0,
                pos1
            );
        }

        foreach(var item in GetBoardItems())
        {
            Gizmos.color = item.IsPassable() ? new Color(item.GetCost() / 255.0f, 0, 1) : Color.black;
            Gizmos.DrawSphere(
                GridToWorldPos(WorldPosToGrid(item.transform.position))
                , GetStep() / 2);
        }
    }
}
