using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO item;

    public void DropItem(Vector2 position)
    {
        Instantiate(item.prefab, position, Quaternion.identity);
    }
}
