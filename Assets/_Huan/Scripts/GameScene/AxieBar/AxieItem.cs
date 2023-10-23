using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxieItem : MonoBehaviour
{
    public AxieSO axie;

    public void PlaceAxie(Vector2 position)
    {
        Instantiate(axie.prefab, position, Quaternion.identity);
    }
}
