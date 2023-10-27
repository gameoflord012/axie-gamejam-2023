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
            ItemSO usedItem = ((Item)ItemPlacingManager.Instance.selectedItem).item;
            UI_Event.Gameplay.OnUseItem.Invoke(usedItem, canvas.gameObject);

            CoinManager.Instance.UseCoin(usedItem.price);
            Debug.Log("Use item" + usedItem.name + " " + canvas.gameObject);
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
