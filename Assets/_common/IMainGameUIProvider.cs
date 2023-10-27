using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMainGameUIProvider
{
    public bool CanSpawnAxie(AxieSO axieSO, Vector2 spawnPosition);

    public float GetBaseHealth();
    public float GetBaseMaxHealth();

    public int GetCurrentCoin();

    public float GetMaxTime();
    public float GetCurrentTime();
}
