using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro dmgText;
    [SerializeField] private float ySpeed = 8f;
    [SerializeField] private float timeBeforDisappear = 1f;
    [SerializeField] private float disappearSpeed = 3f;
    private Color textColor;

    private void Awake()
    {
        dmgText = GetComponent<TextMeshPro>();    
    }

    void Update()
    {
        transform.position += new Vector3(0, ySpeed, 0) * Time.deltaTime;

        timeBeforDisappear -= Time.deltaTime;
        if (timeBeforDisappear < 0)
        {
            textColor.a -= disappearSpeed * Time.deltaTime;
            dmgText.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetValue(int value, Color color)
    {
        dmgText.color = color;
        dmgText.text = value.ToString();
        textColor = dmgText.color;
    }
}
