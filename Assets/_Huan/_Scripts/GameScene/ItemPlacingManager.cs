using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacingManager : MonoBehaviour
{
    public static ItemPlacingManager Instance { get; private set; }

    public AbstractItemSlot[] itemSlots;
    [HideInInspector] public AbstractItem selectedItem = null;
    [HideInInspector] public bool selectingAxie = false;
    [HideInInspector] public bool selectingItem = false;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectItemSlot(AbstractItemSlot slot, bool isAxie)
    {
        DeselectAll();
        slot.Select();
        selectedItem = slot.GetItemInSlot();
        selectingAxie = isAxie;
        selectingItem = !isAxie;
    }

    public void DeselectAll()
    {
        foreach (var itemSlot in itemSlots)
        {
            itemSlot.Deselect();
        }
    }
}
