using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Content;
using UnityEngine;

public class StateController : MonoBehaviour
{
    Dictionary<string, StateBase> getState = new();

    [SerializeField] string nextState;
    [SerializeField] string defaultState;
    [SerializeField] string currentStateString;

    StateBase currentState;
    [SerializeField] bool debug = false;

    public string CurrentStateString { get => currentStateString; }

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
        currentStateString = currentState?.name;

        currentState?.StateUpdateInternal();

        if (currentState == null || currentState.name != nextState) 
            if(!String.IsNullOrEmpty(nextState)) 
                ChangeToState(nextState);

        if (currentState != null)
        {
            ProcessStateTransition(currentState);

            if (currentState.IncludeInAnyState && getState.ContainsKey("any-state"))
            {
                ProcessStateTransition(getState["any-state"]);
            }
        }
    }

    private void ProcessStateTransition(StateBase state)
    {
        foreach (var transition in state.GetTransitions())
        {
            if (transition.NextState == currentState.name) continue;

            if (transition.ShouldTransition)
            {
                ChangeToState(transition.NextState);
                break;
            }
        }
    }

    public void ChangeToState(string stateName)
    {
        if(debug)
            Debug.Log("Change to state " + stateName);

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
