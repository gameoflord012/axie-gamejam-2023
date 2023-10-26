using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItemSlotProvider : MonoBehaviour, IItemSlotQuery
{
    private bool selectable = true;

    public int GetCooldownDuration()
    {
        return 8;
    }

    public bool IsSelectable()
    {
        return selectable;
    }

    public void SetSelectable(bool value)
    {
        selectable = value;
    }
}
