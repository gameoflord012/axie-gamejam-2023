using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour
{
    public void IncreaseHealth()
    {
        H_Events.UI_HealthBar.OnBaseHealthIncrease.Invoke(10);
    }

    public void DecreaseHealth()
    {
        H_Events.UI_HealthBar.OnBaseHealthDecrease.Invoke(15);
    }
}
