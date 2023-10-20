using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BoardItem : MonoBehaviour
{
    [SerializeField] bool unpassable;
    [SerializeField] byte cost = 10;

    public byte GetCost()
    {
        Assert.IsTrue(cost > 0);
        return unpassable ? (byte)0 : cost;
    }

    public bool IsPassable()
    {
        return !unpassable;
    }
}
