using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMainGameUIProvider
{
    public bool CanSpawnAxie(AxieSO axieSO);
    public float GetAxieSpawnCooldown(AxieSO axieSO);
    public float GetAxieCost(AxieSO cost);

    public float GetMainBaseHealth();
}
