using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AxieItemSlot : AbstractItemSlot
{
    [SerializeField] private TMP_Text priceText;

    private void Update()
    {
        UpdatePriceTag();    
    }

    public override void OnSlotSelect()
    {
        if (m_ItemSlotQuery.IsSelectable() == true)
        {
            ItemPlacingManager.Instance.SelectItemSlot(this, true);
        }
    }

    public void StartCooldown()
    {
        button.interactable = false;
        cooldownSlider.gameObject.SetActive(true);
        cooldown = m_ItemSlotQuery.GetCooldownDuration();
        m_ItemSlotQuery.SetSelectable(false);

        StartCoroutine(CooldownCoroutine());
    }

    protected override void UpdatePriceTag()
    {
        int coin = uiProvider.GetCurrentCoin();
        AxieItem axie = (AxieItem)GetItemInSlot();

        if (axie == null)
        {
            priceText.text = "0";
            return;
        }

        priceText.text = axie.GetPrice().ToString();

        if (coin >= axie.GetPrice())
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
