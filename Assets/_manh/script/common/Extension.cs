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
        List<Transform> tree = new();
        tree.Add(transform);

        for(int i = 0; i < tree.Count; i++)
        {
            Transform node = tree[i];
            for (int j = 0; j < node.childCount; j++)
            {
                tree.Add(node.GetChild(j));
            }
        }

        tree.Reverse();
        return tree.ToArray();
    }

    public static GameObject FindSiblingWithTag(this Transform transform, string tag)
    {
        return transform.root.GetAllChild().
            Where(child => child.CompareTag(tag)).
            First()?.gameObject;
    }

    public static T FindSibling<T>(this Transform transform)
    {
        return transform.root.GetAllChild().
            Where(child => child.GetComponent<T>() != null).
            First().GetComponent<T>();
    }
}

