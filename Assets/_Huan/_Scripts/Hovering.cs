using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class Hovering : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private bool canHover = true;
    private GridLayoutGroup glg;
    [SerializeField] private Vector2 childOriSize;

    private void Awake()
    {
        glg = GetComponent<GridLayoutGroup>();

        childOriSize = glg.cellSize;
    }

    public void SetHover(bool possible)
    {
        canHover = possible;
    }

    public void ForceHoverIn()
    {
        glg.cellSize = 1.1f * childOriSize;
    }

    public void ForceHoverOut()
    {
        glg.cellSize = childOriSize;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (canHover)
        {
            glg.cellSize = 1.1f * childOriSize;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (canHover)
        {
            glg.cellSize = childOriSize;
        }
    }
}
