using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/ItemSO", fileName = "New Item SO")]
public class ItemSO : ScriptableObject
{
    public string name;
    public int id;
    public int price;
    public GameObject prefab;
    public Sprite sprite;
}
