using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIProvider : MonoBehaviour, ICharacterUIQuery
{
    public float GetCurrentHealth()
    {
        return transform.FindSibling<Health>().GetHealth();
    }

    public float GetMaxHealth()
    {
        return transform.FindSibling<Health>().MaxHealth;
    }
}
