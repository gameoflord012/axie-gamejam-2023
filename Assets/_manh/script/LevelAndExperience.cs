using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelAndExperience : MonoBehaviour
{
    public UnityEvent<int> onLevelChanged;

    [SerializeField] float currentExp;
    [SerializeField] float expPerLevel;
    [SerializeField] float levelFactor = 0.2f;

    [SerializeField] float dropExpPercentages = 0.5f;
    [SerializeField] [ReadOnly] int currentLevel;

    [SerializeField] bool debug = false;

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
        if (debug)
            currentLevel = GetLevel();
    }

    public float GetExtra()
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

        return exp;
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
}
