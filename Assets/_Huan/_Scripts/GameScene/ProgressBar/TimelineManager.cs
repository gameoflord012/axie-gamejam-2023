using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance { get; private set; }

    [SerializeField] private Slider slider;
    [SerializeField] private float maxTime = 180;
    private float currentTime;

    private void Awake()
    {
        Instance = this;

        currentTime = maxTime;
        slider.maxValue = maxTime;
    }

    void Update()
    {
        if (currentTime < 0)
        {
            UI_Event.Gameplay.OnGameOver.Invoke(true);
            return;
        }

        slider.value = Mathf.Clamp(currentTime, 0f, maxTime);
        currentTime -= Time.deltaTime;
    }

    public float GetMaxTime()
    {
        return maxTime;
    }
}
