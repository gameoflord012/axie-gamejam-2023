using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacter : MonoBehaviour, ICharacterUIQuery
{
    [SerializeField] private CharacterHealthBar healthBar;

    private float maxHealth = 100;
    private float curHealth = 100;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus) == true)
            curHealth = Mathf.Clamp(curHealth - 15, 0, maxHealth);

        if (Input.GetKeyDown(KeyCode.Equals) == true)
            curHealth = Mathf.Clamp(curHealth + 10, 0, maxHealth);
    }

    public float GetCurrentHealth()
    {
        return curHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
