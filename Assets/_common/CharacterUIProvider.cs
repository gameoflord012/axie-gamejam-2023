using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIProvider : MonoBehaviour, ICharacterUIQuery
{
    private float maxHealth = 100;
    private float curHealth = 100;

    public float GetCurentHealth()
    {
        return transform.FindSibling<Health>().GetHealth();
    }

    public float GetMaxHealth()
    {
        return transform.FindSibling<Health>().MaxHealth;
    }
}
