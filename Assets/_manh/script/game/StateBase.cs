using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateBase : MonoBehaviour
{
    public UnityEvent onStateEnter;
    public UnityEvent onStateExit;

    public StateTransition[] GetTransitions()
    {
        return GetComponentsInChildren<StateTransition>();
    }

    public StateController CurrentStateController { get; set; }

    public void StateEnterInternal()
    {
        StateEnter();
        onStateEnter?.Invoke();
    }

    public void StateExitInternal()
    {
        StateExit();
        onStateExit?.Invoke();
    }
    public void StateUpdateInternal()
    {
        StateUpdate();
    }

    public virtual void StateEnter(){ }
    public virtual void StateExit(){ }
    public virtual void StateUpdate(){ }
}
