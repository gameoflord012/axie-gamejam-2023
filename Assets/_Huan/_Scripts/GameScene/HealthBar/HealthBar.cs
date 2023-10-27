using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthText;

    IMainGameUIProvider uiProvider;

    private float maxHealth = 100;
    private float curHealth;

    public float MaxHealth 
    { 
        get => maxHealth; 
        set { maxHealth = value; healthSlider.maxValue = value; }
    }

    private void Awake()
    {
        uiProvider = transform.FindSibling<IMainGameUIProvider>();

        curHealth = MaxHealth;
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString();
    }

    private void Update()
    {
        OnHealthChanged(uiProvider.GetBaseHealth());
        MaxHealth = uiProvider.GetBaseMaxHealth();
    }

    //TODO: SetHealth

    public void OnHealthChanged(float value)
    {
        healthText.text = value.ToString();
    }

    public void OnHealthIncrease(float value)
    {
        curHealth += value;
        if (curHealth > MaxHealth)
            curHealth = MaxHealth;

        healthSlider.value = curHealth;
    }   
    
    public void OnHealthDecrease(float value)
    {
        curHealth -= value;
        if (curHealth < 0)
            curHealth = 0;

        healthSlider.value = curHealth;
    }
}
