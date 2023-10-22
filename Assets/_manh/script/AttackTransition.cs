using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : StateTransition
{
    [SerializeField] ColliderFilter attackCollider;

    public override bool ShouldTransition 
    { 
        get => base.ShouldTransition || attackCollider.NumTouchCols() > 0; 
        set => base.ShouldTransition = value; 
    }
}
