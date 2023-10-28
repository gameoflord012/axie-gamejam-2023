using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthText;

    [SerializeField] private Transform baseObject;
    private CharacterUIProvider uiProvider;

    private float maxHealth = 1000;
    private float curHealth;

    public float MaxHealth 
    { 
        get => maxHealth; 
        set { maxHealth = value; healthSlider.maxValue = value; }
    }

    private void Awake()
    {
        uiProvider = baseObject.GetComponentInChildren<CharacterUIProvider>();

        curHealth = MaxHealth;
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString();
    }

    private void Update()
    {
        MaxHealth = uiProvider.GetMaxHealth();
        curHealth = uiProvider.GetCurrentHealth();

        if (curHealth < healthSlider.value)
            CameraShake.Instance.Shake(0.5f, 0.2f);

        OnHealthChanged(curHealth);
    }

    //TODO: SetHealth

    public void OnHealthChanged(float value)
    {
        healthText.text = value.ToString();
        healthSlider.value = value;
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
