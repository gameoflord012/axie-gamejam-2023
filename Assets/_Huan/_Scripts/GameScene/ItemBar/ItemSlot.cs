using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;

public class ItemSlot : AbstractItemSlot
{
    [SerializeField] private TMP_Text priceText;

    public override void OnSlotSelect()
    {
        if (m_ItemSlotQuery.IsSelectable() == true)
        {
            ItemPlacingManager.Instance.SelectItemSlot(this, false);
        }
    }

    protected override void UpdatePriceTag()
    {
        int coin = uiProvider.GetCurrentCoin();
        Item item = (Item)GetItemInSlot();

        if (item == null)
        {
            priceText.text = "0";
            return;
        }

        priceText.text = item.GetPrice().ToString();

        if (coin >= item.GetPrice())
        {
            priceText.color = Color.white;
            m_ItemSlotQuery.SetSelectable(true);
        }
        else
        {
            priceText.color = Color.red;
            Deselect();
            m_ItemSlotQuery.SetSelectable(false);
            button.interactable = false;
        }
    }
}
