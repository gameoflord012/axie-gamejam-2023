using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Algorithms;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Point = System.Drawing.Point;

public class PathFindingComponent : MonoBehaviour, IPathAgent
{
    [SerializeField] int searchPerFixedUpdate;
    [SerializeField] bool nearestIfNotFound;
    [SerializeField] float agentRadius;
    [SerializeField] float step = 0.5f;
    [SerializeField] int agentMaxDis = 10;

    [SerializeField] LayerMask obstacle;

    int[] neighBourDirX = { 0, 1, 0, -1, -1, 1, 1, -1 };
    int[] neighBourDirY = { 1, 0, -1, 0, 1, 1, -1, -1 };
    IPathFinder pathFinder;
    List<PathFinderNode> pathFindingResult = new();
    Vector2 lastEnd;
    Vector2 lastStart;


    // Start is called before the first frame update
    void Awake()
    {
        pathFinder = new PathFinder(this);

        pathFinder.BoundX = Mathf.CeilToInt(agentMaxDis / step);
        pathFinder.BoundY = Mathf.CeilToInt(agentMaxDis / step);
    }

    public Vector2[] GetGenerateResult()
    {
        if (!CheckPath()) return new Vector2[] { };

        List<Vector2> result = new() { lastStart };
        result.AddRange(pathFindingResult.Select(node => GridToWorld(new Vector2Int(node.X, node.Y))));
        result.Add(lastEnd);

        for (int idx = 1; idx < result.Count - 1; idx++)
        {
            while (idx < result.Count - 1 &&
                Passable(result[idx - 1], result[idx + 1]))
            {
                result.RemoveAt(idx);
            }
        }

        return result.ToArray();
    }

    public bool CheckPath()
    {
        List<Vector2> result = new() { lastStart };
        result.AddRange(pathFindingResult.Select(node => GridToWorld(new Vector2Int(node.X, node.Y))));
        result.Add(lastEnd);

        for (int i = 1; i < result.Count; i++)
        {
            if (Physics2D.Linecast(
                result[i - 1],
                result[i], 
                obstacle).collider) return false;
        }

        return true;
    }

    // Update is called once per frame
    public IEnumerator GeneratePath(Vector2 start, Vector2 end)
    {
        pathFindingResult.Clear();

        var startGrid = WorldToGrid(start);
        var endGrid = WorldToGrid(end);

        yield return pathFinder.FindPath(
            new Point(startGrid.x, startGrid.y), 
            new Point(endGrid.x, endGrid.y), 
            pathFindingResult,
            searchPerFixedUpdate);

        lastStart = start;
        lastEnd = end;
    }

    public Point[] GetNeighbours(Point node)
    {
        List<Point> result = new();

        for(int i = 0; i < 4; i++)
        {
            var newPoint = node;
            newPoint.X += neighBourDirX[i];
            newPoint.Y += neighBourDirY[i];

            if (Physics2D.Linecast(
                GridToWorld(new Vector2Int(node.X, node.Y)),
                GridToWorld(new Vector2Int(newPoint.X, newPoint.Y)),
                obstacle).collider == null)

            {
                result.Add(newPoint);
                Debug.DrawLine(
                    GridToWorld(new Vector2Int(node.X, node.Y)), 
                    GridToWorld(new Vector2Int(newPoint.X, newPoint.Y)));
            }

        }

        return result.ToArray();
    }

    bool Passable(Vector2 A, Vector2 B)
    {
        return Physics2D.CircleCast(
            A,
            Mathf.Sqrt(2) * step,
            B - A,
            (B - A).magnitude, obstacle).collider == null;
    }

    public bool IsPointOnObstacle(Vector2 point)
    {
        return Physics2D.BoxCast(
            WorldToCloset(point), 
            new Vector2(step, step), 
            0, Vector2.zero, 0, obstacle).collider != null;
    }

    public byte GetNodeCost(Point node)
    { 
        return 1;
    }

    Vector2Int WorldToGrid(Vector2 worldPoint)
    {
        return new Vector2Int(Mathf.RoundToInt(worldPoint.x / step), Mathf.RoundToInt(worldPoint.y / step));
    }

    Vector2 GridToWorld(Vector2Int grid)
    { 
        return new Vector2(grid.x * step, grid.y * step);
    }
    
    Vector2 WorldToCloset(Vector2 worldPoint)
    {
        return GridToWorld(WorldToGrid(worldPoint));
    }
}
