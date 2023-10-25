using System.Collections;
using System.Collections.Generic;
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
        if (attackTrigger.NumTouchCols() > 0)
            return attackTrigger.GetTouchCols()[0].GetComponent<Health>();
        else
            return null;
    }

    public void DealDamage()
    {
        foreach(var col in attackTrigger.GetTouchCols())
        {
            var health = col.transform.FindSibling<Health>();
            health.UpdateHealth(this);

            if (!isAreaAttack) break;
        }
    }
}
