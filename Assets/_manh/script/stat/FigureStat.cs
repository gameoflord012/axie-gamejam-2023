using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureStat : MonoBehaviour
{
    [SerializeField] FigureStat_SO stat;

    Health health;
    Attacker attacker;
    PathFindingAgent moveAgent;
    LevelAndExperience level;
    DropCoins coinDrop;

    private void Start()
    {
        if(stat)
        {
            health = transform.FindSibling<Health>();
            attacker = transform.FindSibling<Attacker>();
            moveAgent = transform.FindSibling<PathFindingAgent>();

            level = transform.FindSibling<LevelAndExperience>();

            coinDrop = transform.FindSibling<DropCoins>();
        }

        level.CurrentExp = stat.initialFigureExp;
        level.onLevelChanged.AddListener(UpdateStats);
        UpdateStats(level.GetLevel());

        coinDrop.DropValue = stat.coinDropValue;
    }

    void UpdateStats(int level)
    {
        health.MaxHealth = (uint)(stat.maxHealth + (float)stat.maxHealth * level * stat.maxHealthCofficient);
        attacker.Damage = (uint)(stat.baseDamage + (float)stat.baseDamage * level * stat.baseDamageCofficient);
        moveAgent.Speed = stat.maxSpeed + (float)stat.maxSpeed * level * stat.maxSpeedCofficient;
    }
}
