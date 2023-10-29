using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelAndExperience : MonoBehaviour
{
    public UnityEvent<int> onLevelChanged;

    [SerializeField] float currentExp;
    [SerializeField] float expPerLevel;
    [SerializeField] float levelFactor = 0.2f;

    [SerializeField] float dropExpPercentages = 0.5f;
    [SerializeField] [ReadOnly] int currentLevel;

    [SerializeField] bool debug = false;

    [SerializeField] Slider slider;
    [SerializeField] TMP_Text text;

    public float CurrentExp
    {
        get => currentExp;
        set
        {
            int lastLevel = GetLevel();
            currentExp = value;

            if (lastLevel != GetLevel())
                onLevelChanged?.Invoke(GetLevel());

            currentLevel = GetLevel();
        }
    }

    private void Update()
    {
        if(text)
            text.text = currentLevel.ToString();
        
        if(slider)
            slider.value = GetExtraPercent();
    }

    public float GetExtraPercent()
    {
        float exp = currentExp;
        float per = expPerLevel;
        int result = 0;

        while (exp >= per)
        {
            result++;
            exp -= per;
            per *= 1 + levelFactor;
        }

        return exp / per;
    }

    public int GetLevel()
    {
        float exp = currentExp;
        float per = expPerLevel;
        int result = 0;

        while(exp >= per)
        {
            result++;
            exp -= per;
            per *= 1 + levelFactor;
        }

        return result;
    }

    public float GetDropExp()
    {
        return currentExp * dropExpPercentages;
    }

    private void Start()
    {
        if (slider)
            slider.maxValue = 1;
    }
}
