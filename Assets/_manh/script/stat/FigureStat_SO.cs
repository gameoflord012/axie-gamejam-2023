using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureStat", menuName = "Stats")]
public class FigureStat_SO : ScriptableObject
{
    public int maxHealth = 100;
    public float maxSpeed = 2;
    public int baseDamage = 20;

    public float maxHealthCofficient = 0.5f;
    public float baseDamageCofficient = 0.5f;
    public float maxSpeedCofficient = 0.05f;

    public int coinDropValue;
    public int initialFigureExp;
}
