using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject parentCharacter;
    private ICharacterUIQuery m_CharacterUIQuery;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        if (parentCharacter == null)
            return;

        m_CharacterUIQuery = parentCharacter.GetComponent<ICharacterUIQuery>();
        healthSlider.maxValue = m_CharacterUIQuery.GetMaxHealth();
    }

    private void Update()
    {
        if (parentCharacter == null)
            return;

        // Update health
        healthSlider.value = m_CharacterUIQuery.GetCurentHealth();
    }
}
