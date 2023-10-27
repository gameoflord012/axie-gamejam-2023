using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value { get => value; }
    private int value = 0;

    private Transform target;
    private Vector2 vel;

    private void Start()
    {
        // TODO: coin drop effect

        //
        value = 10;
    }

    private void Update()
    {
        if (target != null)
            transform.position = Vector2.SmoothDamp(transform.position, target.position, ref vel, 0.2f);
    }

    public void SetValue(int newValue)
    {
        value = newValue;
    }

    public void OnSucked(Transform vacuum)
    {
        target = vacuum;
    }
}
