using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureStat : MonoBehaviour
{
    [SerializeField] FigureStat_SO stat;

    private void Start()
    {
        if(stat)
        {
            transform.FindSibling<Health>().MaxHealth = (uint)stat.maxHealth;
            transform.FindSibling<Attacker>().Damage = (uint)stat.baseDamage;
            transform.FindSibling<PathFindingAgent>().Speed = stat.maxSpeed;
        }
    }
}
