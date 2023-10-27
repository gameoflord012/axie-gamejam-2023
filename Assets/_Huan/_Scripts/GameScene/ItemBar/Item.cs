using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : AbstractItem
{
    public ItemSO item;

    public override void PlaceItem(Vector2 position)
    {
        Debug.Log("Placed item: " + item.name);
    }

    public override int GetPrice()
    {
        return item.price;
    }
}
