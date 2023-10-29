using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateBase : MonoBehaviour
{
    public UnityEvent onStateEnter;
    public UnityEvent onStateExit;

    [SerializeField] bool includeInAntState = true;

    [SerializeField] bool autoPlayAndStopSequence = true;
    [SerializeField] bool autoPlayAndStopAnimation = true;

    SequencePlayer[] sequences = { };
    AnimationPlayer animationPlayer;

    private void Awake()
    {
        sequences = transform.GetComponentsInChildren<SequencePlayer>();
        animationPlayer = GetComponentInChildren<AnimationPlayer>();
    }

    public StateTransition[] GetTransitions()
    {
        return GetComponentsInChildren<StateTransition>();
    }

    public StateController CurrentStateController { get; set; }
    public bool IncludeInAnyState { get => includeInAntState; }

    public void StateEnterInternal()
    {
        if(autoPlayAndStopSequence)
        {
            foreach (var sequence in sequences)
            {
                sequence.PlayAll();
            }
        }

        if(autoPlayAndStopAnimation)
            animationPlayer.PlayAnimation();

        StateEnter();
        onStateEnter?.Invoke();
    }

    public void StateExitInternal()
    {
        if (autoPlayAndStopSequence)
        {
            foreach (var sequence in sequences)
            {
                sequence.StopAll();
            }
        }

        if(autoPlayAndStopAnimation)
            animationPlayer.StopAnimation();

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
