using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;

public class ItemSlot : AbstractItemSlot
{
    [SerializeField] private TMP_Text priceText;
    IMainGameUIProvider uiProvider;

    private void Start()
    {
        uiProvider = transform.FindSibling<IMainGameUIProvider>();
    }

    private void Update()
    {
        UpdatePriceTag();
    }

    public override void OnSlotSelect()
    {
        if (m_ItemSlotQuery.IsSelectable() == true)
        {
            ItemPlacingManager.Instance.SelectItemSlot(this, false);
        }
    }

    private void UpdatePriceTag()
    {
        int coin = uiProvider.GetCurrentCoin();
        Item item = (Item) GetItemInSlot();

        if (item == null)
        {
            priceText.text = "0";
            return;
        }
        
        priceText.text = item.GetPrice().ToString();

        if (coin >= item.GetPrice())
        {
            priceText.color = Color.yellow;
            m_ItemSlotQuery.SetSelectable(true);
        }
        else
        {
            priceText.color = Color.red;
            m_ItemSlotQuery.SetSelectable(false);
        }
    }
}
