using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : AbstractItemSlot
{
    public override void OnSlotSelect()
    {
        if (m_ItemSlotQuery.IsSelectable() == true)
        {
            ItemPlacingManager.Instance.SelectItemSlot(this, false);
        }
    }
}
