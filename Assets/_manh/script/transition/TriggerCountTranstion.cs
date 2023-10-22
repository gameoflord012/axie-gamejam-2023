using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerCountTranstion : StateTransition
{
    [SerializeField] ColliderFilter attackCollider;

    [SerializeField] string[] attackTriggerTags;
    [SerializeField] float transitionAmount = 0;

    private void Awake()
    {
        if(attackCollider == null)
        {
            attackCollider = transform.root.
                                GetComponentsInChildren<ColliderFilter>().
                                Where(colFil => attackTriggerTags.Contains(colFil.tag)).
                                First();
        }
    }

    protected override bool ShouldTransitionOverride()
    {
        return attackCollider.NumTouchCols() > transitionAmount;
    }
}
