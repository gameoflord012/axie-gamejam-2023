using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class AxieGround : MonoBehaviour
{
    public GameObject privateSpacePrefab;

    public void OnButtonClicked()
    {
        if ((AxieBarManager.Instance.emptyGround && AxieBarManager.Instance.selectedAxie) == true)
        {
            AxieBarManager.Instance.selectedAxie.PlaceAxie(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

    }
}
