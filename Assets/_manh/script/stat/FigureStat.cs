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

    private void Start()
    {
        if(stat)
        {
            health = transform.FindSibling<Health>();
            attacker = transform.FindSibling<Attacker>();
            moveAgent = transform.FindSibling<PathFindingAgent>();

            level = transform.FindSibling<LevelAndExperience>();
        }

        level.onLevelChanged.AddListener(UpdateStats);
        UpdateStats(level.GetLevel());
    }

    void UpdateStats(int level)
    {
        health.MaxHealth = (uint)(stat.maxHealth * level);
        attacker.Damage = (uint)(stat.baseDamage * level);
        moveAgent.Speed = stat.maxSpeed * level;
    }
}
