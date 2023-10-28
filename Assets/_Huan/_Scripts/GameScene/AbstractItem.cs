using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractItem : MonoBehaviour
{
    [SerializeField] protected Image image;

    public abstract int GetPrice();
    public abstract void PlaceItem(Vector2 position);
}
