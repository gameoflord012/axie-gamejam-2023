using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    IMainGameUIProvider uiProvider;

    [SerializeField] private Slider slider;

    private void Awake()
    {
        uiProvider = transform.FindSibling<IMainGameUIProvider>();
        slider.maxValue = uiProvider.GetMaxTime();
    }

    void Update()
    {
        slider.value = uiProvider.GetCurrentTime();
    }
}
