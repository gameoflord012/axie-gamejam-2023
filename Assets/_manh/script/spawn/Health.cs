using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] uint health;

    public UnityEvent onHealthReachZero;

    public uint GetHealth() { return health; }

    public void UpdateHealth(Attacker attacker)
    {
        if(attacker.Damage >= GetHealth())
        {
            health = 0;
            onHealthReachZero.Invoke();
        }
        else
        {
            health -= attacker.Damage;
        }
    }
}
