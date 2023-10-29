using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverBoard;
    [SerializeField] private GameObject victoryTitle;
    [SerializeField] private GameObject gameOverTitle;
    [SerializeField] private GameObject gameplayCanvas;


    [SerializeField] private Slider slider;
    [SerializeField] private float maxTime = 180;
    private float currentTime;

    private void Awake()
    {
        Instance = this;

        currentTime = maxTime;
        slider.maxValue = maxTime;

        UI_Event.Gameplay.OnGameOver.AddListener(OnGameOver);
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

    private void OnGameOver(bool victory)
    {
        Time.timeScale = 0f;
        CameraShake.Instance.SetShakable(false);
        gameOverBoard.SetActive(true);
        gameplayCanvas.SetActive(false);

        if (victory == true)
        {
            gameOverTitle.SetActive(false);
            victoryTitle.SetActive(true);
        }
        else
        {
            victoryTitle.SetActive(false);
            gameOverTitle.SetActive(true);
        }
    }
}
