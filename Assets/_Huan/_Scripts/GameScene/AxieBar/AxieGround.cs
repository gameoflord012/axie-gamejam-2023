using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class AxieGround : MonoBehaviour
{

    public void OnButtonClicked()
    {
        if (ItemPlacingManager.Instance.selectingAxie == true && ItemPlacingManager.Instance.selectedItem != null)
        {
            ItemPlacingManager.Instance.selectedItem.PlaceItem(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ItemPlacingManager.Instance.DeselectAll();
        }
    }
}
