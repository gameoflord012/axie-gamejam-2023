using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class H_Events
{
    public static class UI_HealthBar
    {
        public static UnityEvent<float> OnBaseHealthIncrease = new UnityEvent<float>();
        public static UnityEvent<float> OnBaseHealthDecrease = new UnityEvent<float>();
        public static UnityEvent<float> OnBaseMaxHealthChange = new UnityEvent<float>();
    }

    public static class UI_Item
    {
        public static UnityEvent<ItemSO, GameObject> OnUseItem = new UnityEvent<ItemSO, GameObject>();
    }

    public static class UI_Axie
    {
        public static UnityEvent<Vector2, AxieSO> OnAxieSpawnPosition = new UnityEvent<Vector2, AxieSO>();
    }

    public static class Coin
    {
        public static UnityEvent OnCoinChange = new UnityEvent();
    }
}
