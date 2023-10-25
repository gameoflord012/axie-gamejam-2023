using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class H_Events
{
    public static class UI_HealthBar
    {
        public static UnityEvent<float> OnHealthIncrease = new UnityEvent<float>();
        public static UnityEvent<float> OnHealthDecrease = new UnityEvent<float>();
        public static UnityEvent<float> OnMaxHealthChange = new UnityEvent<float>();
    }

    public static class UI_Item
    {
        public static UnityEvent<ItemSO, GameObject> OnUseItem = new UnityEvent<ItemSO, GameObject>();
    }
}
