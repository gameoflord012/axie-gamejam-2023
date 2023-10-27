using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainGameProvider : MonoBehaviour, IMainGameUIProvider
{
    [SerializeField] float BaseHealth = 50;
    [SerializeField] float BaseMaxHealth = 100;
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
        throw new System.NotImplementedException();
    }

    public float GetMaxTime()
    {
        throw new System.NotImplementedException();
    }
}
