using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AxiePrivateSpace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public Color invisibleColor, axieSelectedColor, itemSelectedColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = axieSelectedColor;
        // Need to separate the case of axieSelectedColor and itemSelectedColor
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = invisibleColor;
    }
}
