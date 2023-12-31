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
    [SerializeField] private GameObject pointer;

    private void Awake()
    {
        SelectableManager.Current().onSelectableChanged.AddListener(DisplayPointer);
    }

    public void DisplayPointer(GameObject selectedObject)
    {
        if (selectedObject == null)
        {
            pointer.SetActive(false);
            return;
        }

        if (selectedObject.transform.FindSibling<AxiePrivateSpace>() == this)
            pointer.SetActive(true);
        else
            pointer.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ItemPlacingManager.Instance.selectingAxie == false && ItemPlacingManager.Instance.selectingItem == true)
        {
            Item usedItem = ((Item)ItemPlacingManager.Instance.selectedItem);

            usedItem.PlaceItem(transform);
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
