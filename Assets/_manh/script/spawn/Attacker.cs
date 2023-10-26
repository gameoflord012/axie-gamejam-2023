using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ColliderFilter))]
public class Attacker : MonoBehaviour
{
    [SerializeField] uint damage;
    [SerializeField] bool isAreaAttack = false;

    ColliderFilter attackTrigger;

    private void Awake()
    {
        attackTrigger = GetComponent<ColliderFilter>();
    }

    public uint Damage { get => damage; set => damage = value; }

    public Health GetAttackTarget()
    {
        return GetAttackTargets().Count() > 0 ? GetAttackTargets().First() : null;
    }

    public Health[] GetAttackTargets()
    {
        return attackTrigger.GetTouchCols().
            Select(col => col.GetComponent<Health>()).
            Where(health => health.GetHealth() > 0).
            ToArray();
    }

    public void DealDamage()
    {
        foreach(var health in GetAttackTargets())
        {
            health.UpdateHealth(this);

            if (!isAreaAttack) break;
        }
    }
}
