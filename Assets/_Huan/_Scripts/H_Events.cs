using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class H_Events
{
    public static class Navigation
    {
        public static UnityEvent OnStartGame = new UnityEvent();
        public static UnityEvent OnSettings = new UnityEvent();
        public static UnityEvent OnQuit = new UnityEvent();
    }

    public static class HealthBar
    {
        public static UnityEvent<float> OnHealthIncrease = new UnityEvent<float>();
        public static UnityEvent<float> OnHealthDecrease = new UnityEvent<float>();
        public static UnityEvent<float> OnMaxHealthChange = new UnityEvent<float>();
    }
}
