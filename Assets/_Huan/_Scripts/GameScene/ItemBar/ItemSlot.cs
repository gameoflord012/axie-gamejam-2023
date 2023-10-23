using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image image;

    public Color selectedColor, notSelectedColor;

    public void OnSlotSelect()
    {
        ItemBarManager.Instance.SelectItemSlot(this);
    }

    public ItemSO GetItemInSlot()
    {
        if (transform.childCount > 0)
        {
            ItemSO item = transform.GetComponentInChildren<Item>().item;
            return item;
        }

        return null;
    }

    internal void Select()
    {
        image.color = selectedColor;
    }

    internal void Deselect()
    {
        image.color = notSelectedColor;
    }
}
