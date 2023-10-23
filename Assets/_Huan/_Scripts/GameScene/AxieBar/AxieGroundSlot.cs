using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AxieGroundSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public Color selectingColor, notSelectingColor;
    private bool hadAxie = false;
    private GameObject curAxie;

    private void SpawnAxieHere(AxieSO axie)
    {
        if (axie.prefab != null)
        {
            curAxie = Instantiate(axie.prefab, transform.position, Quaternion.identity);
            hadAxie = true;
        }
    }

    public void OnSlotSelected()
    {
        AxieSO selectedAxie = AxieBarManager.Instance.selectedAxie;
        if (hadAxie == false && selectedAxie != null)
        {
            SpawnAxieHere(selectedAxie);
        }

        AxieBarManager.Instance.DeselectAll();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = selectingColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = notSelectingColor;
    }
}
