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
    
    public AxieItem GetAxieInSlot()
    {
        if (transform.childCount > 0)
        {
            AxieItem axie = transform.GetComponentInChildren<AxieItem>();
            return axie;
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
