using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEvent : MonoBehaviour
{
    public UnityEvent onStart;
    //
    private void Start()
    {
        onStart?.Invoke();
    }
}
