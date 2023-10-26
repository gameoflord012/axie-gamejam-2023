using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMainGameUIProvider
{
    public bool CanSpawnAxie(AxieSO axieSO);
    public float GetAxieSpawnCooldown(AxieSO axieSO);
    public float GetAxieCost(AxieSO cost);

    //TODO: Coin system
    public static class Coin
    {
        public static UnityEvent OnCoinChange = new UnityEvent();
    }

    public static class UI_HealthBar
    {
        public static UnityEvent<float> OnBaseHealthIncrease = new UnityEvent<float>();
        public static UnityEvent<float> OnBaseHealthDecrease = new UnityEvent<float>();
        public static UnityEvent<float> OnBaseMaxHealthChange = new UnityEvent<float>();
    }

    public float GetMaxTime();
    public float GetCurrentTime();

    public float GetMainBaseHealth();
}
