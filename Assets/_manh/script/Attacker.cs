using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColliderFilter))]
public class Attacker : MonoBehaviour
{
    [SerializeField] uint damage;

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
}
