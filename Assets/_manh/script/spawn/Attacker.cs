using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ColliderFilter))]
public class Attacker : MonoBehaviour
{
    public UnityEvent<Transform> onAttackerAttackTransform;
    
    [SerializeField] uint damage;
    [SerializeField] bool isAreaAttack = false;
    [SerializeField] bool debug;

    ColliderFilter attackTrigger;

    private void Awake()
    {
        attackTrigger = GetComponent<ColliderFilter>();
    }

    private void Update()
    {
        if(debug)
        {
            Debug.Log("Attack target num: " + GetAttackTargets().Count());
        }
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
            onAttackerAttackTransform?.Invoke(health.transform);

            if (!isAreaAttack) break;
        }
    }
}
