using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateTransition : MonoBehaviour
{
    [SerializeField] string nextState;

    public string NextState { get => nextState; }
    public abstract bool ShouldTransition();
}
