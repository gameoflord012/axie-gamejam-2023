using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/AxieSO", fileName = "New Axie SO")]
public class AxieSO : ScriptableObject
{
    public string name;

    public int placementCost;
    public float cooldownTime;

    public int id;
    public GameObject prefab;
    public Sprite sprite;
}
