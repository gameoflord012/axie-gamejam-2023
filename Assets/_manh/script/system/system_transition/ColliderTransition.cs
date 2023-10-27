using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTransition : StateTransition
{
    [SerializeField] ColliderFilter colliderFilter;

    private void OnEnable()
    {
        colliderFilter.onTriggerEnter.AddListener(EnableTransition);
        colliderFilter.onLastTriggerExit.AddListener(DisableTransition);
    }

    private void OnDisable()
    {
        colliderFilter.onTriggerEnter.RemoveListener(EnableTransition);
        colliderFilter.onLastTriggerExit.RemoveListener(DisableTransition);

    }

    void EnableTransition(Collider2D collider)
    {
        ShouldTransition = true;
    }

    void DisableTransition(Collider2D collider)
    {
        ShouldTransition = false;
    }
}
