using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition : MonoBehaviour
{
    [SerializeField] string nextState;
    [SerializeField] bool reverseCondition = false;
    [SerializeField] bool alwayTransition = false;
    [ReadOnly] [SerializeField] bool canTransition;

    public string NextState { get => nextState; }


    public bool ShouldTransition 
    { 
        get => alwayTransition || (ShouldTransitionOverride() ^ reverseCondition); 
        set => alwayTransition = value; 
    }

    protected virtual bool ShouldTransitionOverride() { return false; }

    private void Update()
    {
        canTransition = ShouldTransition;
    }
}
