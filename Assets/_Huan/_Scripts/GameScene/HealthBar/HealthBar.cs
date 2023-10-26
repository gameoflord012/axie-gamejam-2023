using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthText;

    private float maxHealth = 100;
    private float curHealth;

    private void Awake()
    {
        curHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString();

        H_Events.UI_HealthBar.OnBaseHealthIncrease.AddListener(OnHealthIncrease);
        H_Events.UI_HealthBar.OnBaseHealthDecrease.AddListener(OnHealthDecrease);
    }

    //TODO: SetHealth

    public void OnHealthChanged(float value)
    {
        healthText.text = value.ToString();
    }

    public void OnHealthIncrease(float value)
    {
        curHealth += value;
        if (curHealth > maxHealth)
            curHealth = maxHealth;

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
