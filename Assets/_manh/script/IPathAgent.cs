using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public interface IPathAgent
{
    Point[] GetNeighbours(Point node);
    byte GetNodeCost(Point node);
}
