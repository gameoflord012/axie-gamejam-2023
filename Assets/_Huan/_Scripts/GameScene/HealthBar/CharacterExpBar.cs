using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterExpBar : MonoBehaviour
{
    private ICharacterUIQuery m_CharacterUIQuery;

    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        m_CharacterUIQuery = transform.FindSibling<ICharacterUIQuery>();
    }

    private void Update()
    {
        healthSlider.maxValue = m_CharacterUIQuery.GetMaxHealth();
        healthSlider.value = m_CharacterUIQuery.GetCurrentHealth();

        if (healthSlider.value <= 0)
        {
            healthSlider.gameObject.SetActive(false);
        }
    }
}
