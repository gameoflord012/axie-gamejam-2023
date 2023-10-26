using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIProvider : MonoBehaviour, ICharacterUIQuery
{
    [SerializeField] private CharacterHealthBar healthBar;

    private float maxHealth = 100;
    private float curHealth = 100;

    private void Start()
    {
        healthBar = GetComponentInChildren<CharacterHealthBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus) == true)
            curHealth = Mathf.Clamp(curHealth - 15, 0, maxHealth);

        if (Input.GetKeyDown(KeyCode.Equals) == true)
            curHealth = Mathf.Clamp(curHealth + 10, 0, maxHealth);
    }

    public float GetCurentHealth()
    {
        return transform.FindSibling<Health>().GetHealth();
    }

    public float GetMaxHealth()
    {
        return transform.FindSibling<Health>().MaxHealth;
    }
}
