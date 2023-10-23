using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public static class Extension
{
    public static Transform[] GetAllChild(this Transform transform)
    {
        List<Transform> result = new();
        List<Transform> tree = new();
        tree.Add(transform);

        while (tree.Count > 0)
        {
            Transform node = tree[0];
            for (int i = 0; i < node.childCount; i++)
            {
                tree.Add(node.GetChild(i));
            }

            result.Add(node);

            tree.RemoveAt(0);
        }

        return result.ToArray();
    }

    public static GameObject[] FindGameObjectsWithTag(this Transform transform, string tag)
    {
        return transform.GetAllChild().
            Where(child => child.CompareTag(tag)).
            Select(child => child.gameObject).
            ToArray();
    }

    public static GameObject FindWithTagFromTree(this GameObject gameObject, string tag)
    {
        var result = FindGameObjectsWithTag(gameObject.transform.root, tag);
        return result.Count() > 0 ? result[0] : null;
    }
}

