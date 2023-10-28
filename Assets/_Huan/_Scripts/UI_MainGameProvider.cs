using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainGameProvider : MonoBehaviour, IMainGameUIProvider
{
    [SerializeField] float BaseHealth = 1000;
    [SerializeField] float BaseMaxHealth = 1000;
    public bool CanSpawnAxie(AxieSO axieSO, Vector2 spawnPosition)
    {
        return true;
    }

    public float GetBaseHealth()
    {
        return BaseHealth;
    }

    public float GetBaseMaxHealth()
    {
        return BaseMaxHealth;
    }

    public int GetCurrentCoin()
    {
        return CoinManager.Instance.Coin;
    }

    public float GetCurrentTime()
    {
        return 0;
    }

    public float GetMaxTime()
    {
        return TimelineManager.Instance.GetMaxTime();
    }

}
