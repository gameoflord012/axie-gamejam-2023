using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : StateBase
{
    [SerializeField] Attacker attacker;
    [SerializeField] Transform model;


    public override void StateUpdate()
    {
        if (attacker.GetAttackTarget() == null) return;

        if (attacker.GetAttackTarget().transform.position.x > transform.position.x)
            model.localScale = new Vector2(-Mathf.Abs(model.localScale.x), model.localScale.y);
        else
            model.localScale = new Vector2(Mathf.Abs(model.localScale.x), model.localScale.y);
    }
}
