using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureStat", menuName = "Stats")]
public class FigureStat_SO : ScriptableObject
{
    public int maxHealth;
    public float maxSpeed;
    public int baseDamage;
}
