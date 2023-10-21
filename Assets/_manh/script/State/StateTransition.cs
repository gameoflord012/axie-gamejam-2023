using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition : MonoBehaviour
{
    [SerializeField] string nextState;
    [SerializeField] bool shouldTransition = false;

    public string NextState { get => nextState; }

    public bool ShouldTransition { get => shouldTransition; set => shouldTransition = value; }
}
