using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBarManager : MonoBehaviour
{
    public static ItemBarManager Instance { get; private set; }

    public ItemSlot[] itemSlots;
    [HideInInspector] public ItemSO selectedItem = null;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectItemSlot(ItemSlot slot)
    {
        DeselectAll();
        slot.Select();
        selectedItem = slot.GetItemInSlot();
    }

    public void DeselectAll()
    {
        foreach (var itemSlot in itemSlots)
        {
            itemSlot.Deselect();
        }
    }
}
