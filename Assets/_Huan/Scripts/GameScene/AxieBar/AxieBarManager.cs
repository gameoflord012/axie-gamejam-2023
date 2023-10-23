using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxieBarManager : MonoBehaviour
{
    public static AxieBarManager Instance { get; private set; }

    public AxieItemSlot[] axieItemSlots;

    private void Awake()
    {
        Instance = this;    
    }

    public void SelectAxieSlot(AxieItemSlot slot)
    {
        DeselectAll();
        slot.Select();
    }

    public void DeselectAll()
    {
        foreach (var axieItemSlot in axieItemSlots)
        {
            axieItemSlot.Deselect();
        }
    }
}
