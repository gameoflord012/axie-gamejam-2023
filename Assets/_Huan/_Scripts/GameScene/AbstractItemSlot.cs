using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractItemSlot : MonoBehaviour
{
    public Image image;

    public Color selectedColor, notSelectedColor;

    public abstract void OnSlotSelect();

    public AbstractItem GetItemInSlot()
    {
        if (transform.childCount > 0)
        {
            AbstractItem item = transform.GetComponentInChildren<AbstractItem>();
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
