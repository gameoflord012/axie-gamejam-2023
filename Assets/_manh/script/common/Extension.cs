using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public static class Extension
{
    public static Vector2 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
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

    public static Transform[] BottomUpSearch(this Transform node)
    {
        Transform previousNode = null;
        List<Transform> result = new();
        
        while(node)
        {
            result.Add(node);

            for (int i = 0; i < node.childCount; i++)
            {
                var child = node.GetChild(i);

                if (child == previousNode)
                    continue;

                result.AddRange(child.GetAllChild());
            }

            previousNode = node;
            node = node.parent;
        }

        return result.ToArray();
    }

    public static GameObject FindSiblingWithTag(this Transform transform, string tag)
    {

        var result = transform. BottomUpSearch().
                                Where(child => child.CompareTag(tag));

        return result.Count() > 0 ? result.First().gameObject : null;
    }

    public static T FindSibling<T>(this Transform transform)
    {
        var result = transform.BottomUpSearch().
            Where(child => child.GetComponent<T>() != null);

        return result.Count() > 0 ? result.First().GetComponent<T>() : default(T);
    }
}

