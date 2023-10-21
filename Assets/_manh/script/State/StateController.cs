using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    Dictionary<string, StateBase> getState = new();

    [SerializeField] string nextState;
    [SerializeField] string defaultState;

    StateBase currentState;

    private void Start()
    {
        foreach(var state in GetComponentsInChildren<StateBase>())
        {
            getState[state.name] = state;
        }

        ChangeToState(defaultState);
    }

    private void Update()
    {
        currentState?.StateUpdateInternal();

        if (currentState == null || currentState.name != nextState) 
            if(!String.IsNullOrEmpty(nextState)) 
                ChangeToState(nextState);

        if (currentState != null)
        {
            foreach (var transition in currentState.GetTransitions())
            {
                if (transition.ShouldTransition)
                {
                    ChangeToState(transition.NextState);
                    break;
                }
            }
        }
    }

    public void ChangeToState(string stateName)
    {
        if(getState.ContainsKey(stateName))
        {
            currentState?.StateExitInternal();
            currentState = getState[stateName];
            currentState.StateEnterInternal();
        }
        else
        {
            Debug.LogWarning("state is not valid: " + stateName);
        }
    }
}
