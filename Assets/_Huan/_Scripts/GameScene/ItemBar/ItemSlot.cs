using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : AbstractItemSlot
{
    public override void OnSlotSelect()
    {
        ItemPlacingManager.Instance.SelectItemSlot(this, false);
    }
}
