using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxieItemSlot : MonoBehaviour
{
    public Image image;

    public Color selectedColor, notSelectedColor;

    public void OnSlotSelect()
    {
        AxieBarManager.Instance.SelectAxieSlot(this);
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
