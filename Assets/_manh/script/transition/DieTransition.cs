using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTransition : StateTransition
{
    [SerializeField] Health health;

    protected override bool ShouldTransitionOverride()
    {
        return health.GetHealth() == 0;
    }
}
