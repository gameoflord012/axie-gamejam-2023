using System.Collections;
using System.Collections.Generic;
using Algorithms;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Point = System.Drawing.Point;

public class PathFindingComponent : MonoBehaviour
{
    [SerializeField] int searchPerFixedUpdate;

    IPathFinder pathFinder;
    List<PathFinderNode> pathFindingResult = new();


    // Start is called before the first frame update
    void Awake()
    {
        pathFinder = new PathFinder();

        pathFinder.HeavyDiagonals = true;
    }

    public PathFinderNode[] GetGenerateResult()
    {
        return pathFindingResult.ToArray();
    }

    // Update is called once per frame
    public IEnumerator GeneratePath(byte[,] grid, Vector2Int start, Vector2Int end)
    {
        pathFindingResult.Clear();
        yield return pathFinder.FindPath(
            new Point(start.x, start.y), 
            new Point(end.x, end.y), 
            grid, pathFindingResult,
            searchPerFixedUpdate);
    }
}
