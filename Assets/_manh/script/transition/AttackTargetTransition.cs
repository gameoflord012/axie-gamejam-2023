using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class AttackTargetTransition : StateTransition
{
    Attacker attacker;
    [SerializeField] bool traisitionWhenHaveTargets = true;
    private void Start()
    {
        attacker = transform.FindSibling<Attacker>();
    }
    protected override bool ShouldTransitionOverride()
    {
        return traisitionWhenHaveTargets ? 
            attacker.GetAttackTargets().Count() > 0 :
            attacker.GetAttackTargets().Count() == 0;
    }
}
