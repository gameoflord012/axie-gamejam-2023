using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public static class Extension
{
    public static GameObject[] FindGameObjectsWithTag(this Transform transform, string tag)
    {
        List<GameObject> result = new();
        List<Transform> tree = new();
        tree.Add(transform);

        while(tree.Count > 0)
        {
            Transform node = tree[0];
            for(int i = 0; i < node.childCount; i++)
            {
                tree.Add(node.GetChild(i));
            }

            if(node.CompareTag(tag))
            {
                result.Add(node.gameObject);
            }

            tree.RemoveAt(0);
        }

        return result.ToArray();
    }

    public static GameObject FindWithTagFromTree(this GameObject gameObject, string tag)
    {
        var result = FindGameObjectsWithTag(gameObject.transform.root, tag);
        return result.Count() > 0 ? result[0] : null;
    }
}

