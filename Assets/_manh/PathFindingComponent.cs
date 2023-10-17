using System.Collections;
using System.Collections.Generic;
using Algorithms;
using UnityEngine;

using Point = System.Drawing.Point;

public class PathFinding2D : MonoBehaviour
{
    [SerializeField] byte[,] grid;
    IPathFinder pathFinder;
    List<PathFinderNode> pathFindingResult = new();


    // Start is called before the first frame update
    void Start()
    {
        pathFinder = new PathFinder();

        grid = new byte[,] {
            { 1, 1, 1, 1},
            { 1, 1, 1, 1},
            { 1, 1, 10, 1},
            { 1, 1, 1, 1}
        };

        StartCoroutine(FindPath());

    }

    // Update is called once per frame
    IEnumerator FindPath()
    {
        pathFindingResult.Clear();
        yield return pathFinder.FindPath(new Point(0, 0), new Point(3, 3), grid, pathFindingResult);

        //foreach(var node in pathFindingResult)
        //{
        //    Debug.Log(node.X + " " + node.Y);
        //}
    }
}
