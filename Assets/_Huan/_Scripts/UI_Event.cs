using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class UI_Event
{
    public static class Gameplay
    {
        // tha item vao axie
        public static UnityEvent<ItemSO, GameObject> OnUseItem = new UnityEvent<ItemSO, GameObject>();
        public static UnityEvent<Vector2, AxieSO> OnAxieSpawnPosition = new UnityEvent<Vector2, AxieSO>();
        
        // true la win, false la lose
        public static UnityEvent<bool> OnGameOver = new UnityEvent<bool>();
    }
}
