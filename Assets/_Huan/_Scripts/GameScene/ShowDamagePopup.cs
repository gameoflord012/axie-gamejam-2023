using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDamagePopup : MonoBehaviour
{
    [SerializeField] private GameObject dmgPopupPrefab;

    private void Awake()
    {
        UI_Event.Gameplay.OnDamagePopup.AddListener(AddDamagePopup);
    }

    private void AddDamagePopup(Vector2 position, int value, Color color)
    {
        DamagePopup newPopup = Instantiate(dmgPopupPrefab, position, Quaternion.identity).GetComponent<DamagePopup>();
        newPopup.SetValue(value, color);
    }
}
