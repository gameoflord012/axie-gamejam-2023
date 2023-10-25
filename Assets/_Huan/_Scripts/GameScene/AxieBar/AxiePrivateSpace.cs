using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AxiePrivateSpace : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image image;
    [SerializeField] private Color invisibleColor, axieSelectedColor, itemSelectedColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ItemPlacingManager.Instance.selectingAxie == false && ItemPlacingManager.Instance.selectingItem == true)
        {
            H_Events.UI_Item.OnUseItem.Invoke(((Item)ItemPlacingManager.Instance.selectedItem).item, canvas.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ItemPlacingManager.Instance.selectingAxie == true)
            image.color = axieSelectedColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = invisibleColor;
    }
}
