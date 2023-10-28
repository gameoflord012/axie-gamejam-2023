using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] uint health;
    [SerializeField] uint maxHealth;

    public UnityEvent onHealthReachZero;

    public uint MaxHealth 
    { 
        get => maxHealth; 
        set { maxHealth = value; health = maxHealth; } 
    }

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

    public void Heal(uint value)
    {
        if (health + value >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += value;
        }
    }    
}
