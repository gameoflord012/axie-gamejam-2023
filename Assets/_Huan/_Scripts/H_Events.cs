using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class H_Events
{
    //TODO: chuyen qua UIProvider
    public static class UI_HealthBar
    {
        public static UnityEvent<float> OnBaseHealthIncrease = new UnityEvent<float>();
        public static UnityEvent<float> OnBaseHealthDecrease = new UnityEvent<float>();
        public static UnityEvent<float> OnBaseMaxHealthChange = new UnityEvent<float>();
    }

    public static class UI_Item
    {
        // tha item vao axie
        public static UnityEvent<ItemSO, GameObject> OnUseItem = new UnityEvent<ItemSO, GameObject>();
    }

    public static class UI_Axie
    {
        //TODO
        public static UnityEvent<Vector2, AxieSO> OnAxieSpawnPosition = new UnityEvent<Vector2, AxieSO>();
    }

    //TODO: Coin system
    public static class Coin
    {
        //TODO: chuyen qua UIProvider
        public static UnityEvent OnCoinChange = new UnityEvent();
    }
}
