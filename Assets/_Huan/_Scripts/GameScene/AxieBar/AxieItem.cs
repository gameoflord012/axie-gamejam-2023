using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxieItem : AbstractItem
{
    public AxieSO axie;

    public override void PlaceItem(Vector2 position)
    {
        Instantiate(axie.prefab, position, Quaternion.identity);
    }
}
