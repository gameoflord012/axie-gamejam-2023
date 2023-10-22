using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : StateTransition
{
    [SerializeField] ColliderFilter attackCollider;

    private void Awake()
    {
        if(attackCollider == null)
        {
            attackCollider = transform.root.
                                GetComponentInChildren<Attacker>().
                                GetComponent<ColliderFilter>();
        }
    }

    protected override bool ShouldTransitionOverride()
    {
        return attackCollider.NumTouchCols() > 0;
    }
}
