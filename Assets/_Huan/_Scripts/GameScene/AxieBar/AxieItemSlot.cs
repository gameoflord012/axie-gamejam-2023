using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxieItemSlot : AbstractItemSlot
{
    public override void OnSlotSelect()
    {
        if (m_ItemSlotQuery.IsSelectable() == true)
        {
            ItemPlacingManager.Instance.SelectItemSlot(this, true);

            button.interactable = false;
            cooldownSlider.gameObject.SetActive(true);
            cooldown = m_ItemSlotQuery.GetCooldownDuration();
            m_ItemSlotQuery.SetSelectable(false);

            StartCoroutine(CooldownCoroutine());
        }
    }
}
