using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AttackSequence : BaseSequence
{
    [SerializeField] Attacker attacker;
    [SerializeField] Transform modelTransform;

    private void Start()
    {
        if(!attacker)
            attacker = transform.root.GetComponentInChildren<Attacker>();
    }

    protected override IEnumerator GetSequenceImp()
    {
        if (attacker.GetAttackTarget() == null) yield break;

        attacker.DealDamage();
    }
}
