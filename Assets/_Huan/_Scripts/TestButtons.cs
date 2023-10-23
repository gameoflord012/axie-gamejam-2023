using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour
{
    public void IncreaseHealth()
    {
        H_Events.HealthBar.OnHealthIncrease.Invoke(10);
    }

    public void DecreaseHealth()
    {
        H_Events.HealthBar.OnHealthDecrease.Invoke(15);
    }
}
